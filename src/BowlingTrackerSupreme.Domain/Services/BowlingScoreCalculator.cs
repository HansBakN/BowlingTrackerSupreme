using BowlingTrackerSupreme.Domain.Models;

namespace BowlingTrackerSupreme.Domain.Services;

// TODO: needs testing. May not be accurate at all.
public class BowlingScoreCalculator
{
    public int CalculateScore(List<Frame> frames)
    {
        foreach (var frame in frames)
        {
            frame.Score = CalculateScore(frame, frames);
        }
        
        return frames.Sum(frame => frame.Score ?? 0);
    }

    public int? CalculateScore(Frame currentFrame, List<Frame> otherFrames)
    {
        if (currentFrame is FinalFrame finalFrame)
        {
            return CalculateFinalFrameScore(finalFrame);
        }

        if (currentFrame.IsStrike)
        {
            var nextFrame = otherFrames.ElementAtOrDefault(currentFrame.FrameNumber + 1);

            if (nextFrame == null)
            {
                return null;
            }
            
            var strikeBonus = GetStrikeBonus(nextFrame, otherFrames);
            
            return 10 + strikeBonus;
        }
        
        if (currentFrame.IsSpare)
        {
            var nextFrame = otherFrames.ElementAtOrDefault(currentFrame.FrameNumber + 1);

            if (nextFrame == null)
            {
                return null;
            }

            var spareBonus = GetSpareBonus(nextFrame);
            
            return 10 + spareBonus;
        }

        if (currentFrame.SecondRoll == null)
        {
            return null;
        }

        return currentFrame.AllRolls.Sum(r => r!.PinsHit);
    }

    private int? GetSpareBonus(Frame nextFrame)
    {
        return nextFrame?.FirstRoll?.PinsHit;
    }

    private int? GetStrikeBonus(Frame nextFrame, List<Frame> otherFrames)
    {
        if (nextFrame == null) return null;
        
        if (nextFrame.IsStrike)
        {
            var nextNextFrame = otherFrames.ElementAtOrDefault(nextFrame.FrameNumber + 1);
            if (nextNextFrame == null) return null;

            return 10 + nextNextFrame.FirstRoll?.PinsHit;
        }

        return nextFrame.AllRolls.Take(2).Sum(r => r!.PinsHit);
    }

    public int? CalculateFinalFrameScore(FinalFrame finalFrame)
    {
        var rolls = finalFrame.AllRolls.ToList();
        
        if (finalFrame.IsStrike)
        {
            return 10 + rolls.Skip(1).Take(2).Sum(r => r?.PinsHit ?? 0);
        }

        if (finalFrame.IsSpare)
        {
            int? spareBonus = (rolls.Count > 2 ? rolls[2]?.PinsHit ?? 0 : null);
            return 10 + spareBonus;
        }

        return rolls.Sum(r => r?.PinsHit ?? 0 );
    }
}