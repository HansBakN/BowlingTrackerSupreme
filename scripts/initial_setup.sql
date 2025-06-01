CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE TABLE "Players" (
        "Id" uuid NOT NULL,
        "Name" text NOT NULL,
        CONSTRAINT "PK_Players" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE TABLE "Games" (
        "Id" uuid NOT NULL,
        "WinningPlayerId" uuid NOT NULL,
        CONSTRAINT "PK_Games" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Games_Players_WinningPlayerId" FOREIGN KEY ("WinningPlayerId") REFERENCES "Players" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE TABLE "GamePlayer" (
        "GameParticipationId" uuid NOT NULL,
        "ParticipantsId" uuid NOT NULL,
        CONSTRAINT "PK_GamePlayer" PRIMARY KEY ("GameParticipationId", "ParticipantsId"),
        CONSTRAINT "FK_GamePlayer_Games_GameParticipationId" FOREIGN KEY ("GameParticipationId") REFERENCES "Games" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_GamePlayer_Players_ParticipantsId" FOREIGN KEY ("ParticipantsId") REFERENCES "Players" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE TABLE "PlayerGames" (
        "Id" uuid NOT NULL,
        "PlayerId" uuid NOT NULL,
        "GameId" uuid NOT NULL,
        CONSTRAINT "PK_PlayerGames" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_PlayerGames_Games_GameId" FOREIGN KEY ("GameId") REFERENCES "Games" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_PlayerGames_Players_PlayerId" FOREIGN KEY ("PlayerId") REFERENCES "Players" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE TABLE "Frames" (
        "Id" uuid NOT NULL,
        "PlayerGameId" uuid NOT NULL,
        "FirstRollId" uuid NOT NULL,
        "FirstRoll_PinsHit" integer NOT NULL,
        "SecondRollId" uuid NOT NULL,
        "SecondRoll_PinsHit" integer,
        "FrameNumber" integer NOT NULL,
        "Discriminator" character varying(13) NOT NULL,
        "ThirdRoll_PinsHit" integer,
        CONSTRAINT "PK_Frames" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Frames_PlayerGames_PlayerGameId" FOREIGN KEY ("PlayerGameId") REFERENCES "PlayerGames" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE INDEX "IX_Frames_PlayerGameId" ON "Frames" ("PlayerGameId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE INDEX "IX_GamePlayer_ParticipantsId" ON "GamePlayer" ("ParticipantsId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE INDEX "IX_Games_WinningPlayerId" ON "Games" ("WinningPlayerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE INDEX "IX_PlayerGames_GameId" ON "PlayerGames" ("GameId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    CREATE INDEX "IX_PlayerGames_PlayerId" ON "PlayerGames" ("PlayerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125122446_Initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250125122446_Initial', '8.0.12');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125144934_AddedScoreToFrame') THEN
    ALTER TABLE "Frames" ADD "Score" integer;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125144934_AddedScoreToFrame') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250125144934_AddedScoreToFrame', '8.0.12');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125183500_AddedDateTimesToGames') THEN
    ALTER TABLE "Games" ADD "DateCreated" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125183500_AddedDateTimesToGames') THEN
    ALTER TABLE "Games" ADD "DatePlayed" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250125183500_AddedDateTimesToGames') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250125183500_AddedDateTimesToGames', '8.0.12');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Games" DROP COLUMN "DateCreated";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Games" RENAME COLUMN "DatePlayed" TO "PlayedOn";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Players" ADD "CreatedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Players" ADD "ModifiedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "PlayerGames" ADD "CreatedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "PlayerGames" ADD "ModifiedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Games" ADD "CreatedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Games" ADD "ModifiedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Frames" ADD "CreatedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    ALTER TABLE "Frames" ADD "ModifiedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now()));
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250225212756_AddedCreatedOnModifiedOn') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250225212756_AddedCreatedOnModifiedOn', '8.0.12');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP CONSTRAINT "FK_Frames_PlayerGames_PlayerGameId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Games" DROP CONSTRAINT "FK_Games_Players_WinningPlayerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    DROP TABLE "GamePlayer";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    DROP TABLE "PlayerGames";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Players" DROP CONSTRAINT "PK_Players";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Games" DROP CONSTRAINT "PK_Games";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    DROP INDEX "IX_Games_WinningPlayerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP CONSTRAINT "PK_Frames";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    DROP INDEX "IX_Frames_PlayerGameId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Games" DROP COLUMN "WinningPlayerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP COLUMN "CreatedOn";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP COLUMN "Discriminator";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP COLUMN "FirstRollId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP COLUMN "ModifiedOn";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP COLUMN "PlayerGameId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP COLUMN "SecondRoll_PinsHit";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" DROP COLUMN "ThirdRoll_PinsHit";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Players" RENAME TO "PlayerSet";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Games" RENAME TO "GameSet";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "Frames" RENAME TO "FrameSet";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "PlayerSet" RENAME COLUMN "Name" TO "UserName";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" RENAME COLUMN "SecondRollId" TO "GamePlayerId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" RENAME COLUMN "FrameNumber" TO "ThirdRoll";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" RENAME COLUMN "FirstRoll_PinsHit" TO "SecondRoll";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "GameSet" ADD "GameNumber" integer NOT NULL DEFAULT 0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "GameSet" ADD "Lane" integer NOT NULL DEFAULT 0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    UPDATE "FrameSet" SET "Score" = 0 WHERE "Score" IS NULL;
    ALTER TABLE "FrameSet" ALTER COLUMN "Score" SET NOT NULL;
    ALTER TABLE "FrameSet" ALTER COLUMN "Score" SET DEFAULT 0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" ADD "AccumulatedScore" integer NOT NULL DEFAULT 0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" ADD "FirstRoll" integer NOT NULL DEFAULT 0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" ADD "Index" integer NOT NULL DEFAULT 0;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "PlayerSet" ADD CONSTRAINT "PK_PlayerSet" PRIMARY KEY ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "GameSet" ADD CONSTRAINT "PK_GameSet" PRIMARY KEY ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" ADD CONSTRAINT "PK_FrameSet" PRIMARY KEY ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    CREATE TABLE "PlayerNicknameSet" (
        "Id" uuid NOT NULL,
        "PlayerId" uuid NOT NULL,
        "Nickname" text NOT NULL,
        "CreatedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now())),
        "ModifiedOn" timestamp with time zone NOT NULL DEFAULT (timezone('utc', now())),
        CONSTRAINT "PK_PlayerNicknameSet" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_PlayerNicknameSet_PlayerSet_PlayerId" FOREIGN KEY ("PlayerId") REFERENCES "PlayerSet" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    CREATE TABLE "GamePlayerSet" (
        "Id" uuid NOT NULL,
        "GameId" uuid NOT NULL,
        "PlayerId" uuid NOT NULL,
        "PlayerNicknameId" uuid,
        "TotalScore" integer NOT NULL,
        CONSTRAINT "PK_GamePlayerSet" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_GamePlayerSet_GameSet_GameId" FOREIGN KEY ("GameId") REFERENCES "GameSet" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_GamePlayerSet_PlayerNicknameSet_PlayerNicknameId" FOREIGN KEY ("PlayerNicknameId") REFERENCES "PlayerNicknameSet" ("Id"),
        CONSTRAINT "FK_GamePlayerSet_PlayerSet_PlayerId" FOREIGN KEY ("PlayerId") REFERENCES "PlayerSet" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    CREATE INDEX "IX_FrameSet_GamePlayerId" ON "FrameSet" ("GamePlayerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    CREATE INDEX "IX_GamePlayerSet_GameId" ON "GamePlayerSet" ("GameId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    CREATE INDEX "IX_GamePlayerSet_PlayerId" ON "GamePlayerSet" ("PlayerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    CREATE INDEX "IX_GamePlayerSet_PlayerNicknameId" ON "GamePlayerSet" ("PlayerNicknameId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    CREATE INDEX "IX_PlayerNicknameSet_PlayerId" ON "PlayerNicknameSet" ("PlayerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    ALTER TABLE "FrameSet" ADD CONSTRAINT "FK_FrameSet_GamePlayerSet_GamePlayerId" FOREIGN KEY ("GamePlayerId") REFERENCES "GamePlayerSet" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250525214244_FixedDBStructure') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250525214244_FixedDBStructure', '8.0.12');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250530214638_ApiKey') THEN
    CREATE TABLE "ApiKeySet" (
        "Id" uuid NOT NULL,
        "Key" text NOT NULL,
        "Description" text NOT NULL,
        "CreatedOn" timestamp with time zone NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_ApiKeySet" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250530214638_ApiKey') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250530214638_ApiKey', '8.0.12');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250601090032_FixFrame') THEN
    ALTER TABLE "FrameSet" ALTER COLUMN "ThirdRoll" DROP NOT NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250601090032_FixFrame') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250601090032_FixFrame', '8.0.12');
    END IF;
END $EF$;
COMMIT;


