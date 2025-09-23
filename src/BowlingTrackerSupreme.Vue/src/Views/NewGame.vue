<script setup lang="ts">
import { reactive } from 'vue'

type Roll = number

interface Frame {
  rolls: Roll[] // 1–3 rolls depending on 10th frame
}

interface Game {
  frames: Frame[] // always length 10
}

interface FrameScore {
  frameIndex: number
  score: number | null
  runningTotal: number | null
}

// Player data structure
const createPlayer = (name = '') => ({
  name,
  scores: Array.from({ length: 10 }, () => ({ roll1: '', roll2: '', roll3: '' })),
  frameTotals: Array.from({ length: 10 }, () => 0),
  totalScore: 0
})

// Initialize with 3 players
const players = reactive([
  createPlayer('Dalf'),
  createPlayer('Madkasse'),
  createPlayer('Præste Hunden')
]);

const dateOfGame = reactive({ value: new Date().toISOString().substr(0, 10) })

// Add/Remove players
const addPlayer = () => players.push(createPlayer())
const removePlayer = () => { if (players.length > 1) players.pop() }

// --- Bowling scoring functions from your TypeScript module ---
function calculateScores(game: Game): FrameScore[] {
  const scores: FrameScore[] = []
  let runningTotal = 0

  for (let i = 0; i < 10; i++) {
    const frameScore = getFrameScore(game, i)
    if (frameScore != null) {
      runningTotal += frameScore
      scores.push({ frameIndex: i, score: frameScore, runningTotal })
    } else {
      scores.push({ frameIndex: i, score: null, runningTotal: null })
    }
  }

  return scores
}

function getFrameScore(game: Game, index: number): number | null {
  const frame = game.frames[index]
  const rolls = flattenRolls(game)
  const rollIndex = getRollIndex(game, index)

  if (index === 9) return frame.rolls.reduce((a, b) => a + b, 0)

  if (frame.rolls[0] === 10) {
    if (rolls.length <= rollIndex + 2) return null
    return 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2]
  }

  if (frame.rolls.length === 2 && frame.rolls[0] + frame.rolls[1] === 10) {
    if (rolls.length <= rollIndex + 2) return null
    return 10 + rolls[rollIndex + 2]
  }

  if (frame.rolls.length === 2) return frame.rolls[0] + frame.rolls[1]

  return null
}

function flattenRolls(game: Game): Roll[] {
  return game.frames.flatMap(f => f.rolls)
}

function getRollIndex(game: Game, frameIndex: number): number {
  return game.frames.slice(0, frameIndex).reduce((sum, f) => sum + f.rolls.length, 0)
}

// --- Update scores using the new scoring system ---
const updateScore = (playerIndex: number) => {
  const player = players[playerIndex]

  // Build a Game object from player input
  const game: Game = {
    frames: player.scores.map(f => {
      const rolls: number[] = []

      const roll1 = f.roll1.toUpperCase() === 'X' ? 10 : parseInt(f.roll1) || 0
      rolls.push(roll1)

      if (f.roll2 === '/') rolls.push(10 - roll1)
      else if (f.roll2.toUpperCase() === 'X') rolls.push(10)
      else rolls.push(parseInt(f.roll2) || 0)

      if (f.roll3) {
        if (f.roll3.toUpperCase() === 'X') rolls.push(10)
        else if (f.roll3 === '/') rolls.push(10 - rolls[1])
        else rolls.push(parseInt(f.roll3) || 0)
      }

      return { rolls }
    })
  }

  const frameScores = calculateScores(game)

  // Update reactive data
  frameScores.forEach((fs, idx) => {
    player.frameTotals[idx] = fs.runningTotal ?? 0
  })
  player.totalScore = frameScores[9].runningTotal ?? 0
}

const saveGame = () => {
    // Send to api
    console.log(dateOfGame.value);
    console.log(players);
}
</script>

<template>
    <div class="p-6 bg-gray-50 min-h-screen">
        <div class="max-w-6xl mx-auto bg-white border-2 border-gray-800 shadow-lg">
            <!-- Header -->
            <div class="border-b-2 border-gray-800 p-3 bg-gray-100">
                <div class="flex justify-between items-center">
                    <div class="flex gap-8">

                        <!-- Add Player Button -->
                        <div class="border-gray-300">
                            <button @click="addPlayer"
                                class="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 transition-colors">
                                Tilføj spiller
                            </button>
                            <button @click="removePlayer" v-if="players.length > 1"
                                class="ml-2 px-4 py-2 bg-red-500 text-white rounded hover:bg-red-600 transition-colors">
                                Fjern spiller
                            </button>
                            <button @click="saveGame" v-if="players.length > 1"
                                class="ml-10 px-4 py-2 bg-green-500 text-white rounded hover:bg-red-600 transition-colors">
                                Gem spil
                            </button>
                        </div>
                    </div>
                    <span class="font-bold">
                        <input v-model="dateOfGame" type="date" class="border border-gray-300 rounded px-2 py-1" />
                    </span>
                </div>
            </div>

            <!-- Scorecard Table -->
            <div class="overflow-x-auto">
                <table class="w-full border-collapse">
                    <!-- Column Headers -->
                    <thead>
                        <tr class="bg-gray-100">
                            <th class="border border-gray-800 p-2 text-left font-bold min-w-24">Spiller</th>
                            <th v-for="frame in 10" :key="frame"
                                class="border border-gray-800 p-2 text-center font-bold w-16">
                                {{ frame }}
                            </th>
                            <th class="border border-gray-800 p-2 text-center font-bold w-20">Total</th>
                        </tr>
                    </thead>

                    <tbody>
                        <!-- Player Rows -->
                        <tr v-for="(player, playerIndex) in players" :key="playerIndex" class="hover:bg-gray-50">
                            <!-- Player Name -->
                            <td class="border border-gray-800 p-2 font-medium bg-gray-50">
                                <input v-model="player.name"
                                    class="w-full bg-transparent border-none outline-none font-medium"
                                    placeholder="Player name" />
                            </td>

                            <!-- Frame Scores -->
                            <td v-for="frame in 10" :key="frame"
                                class="border border-gray-800 p-1 text-center relative">
                                <div class="flex">
                                    <!-- First roll -->
                                    <input v-model="player.scores[frame - 1].roll1"
                                        @input="updateScore(playerIndex)"
                                        class="w-6 h-6 text-xs text-center border-none outline-none bg-transparent"
                                        maxlength="2" />
                                    <!-- Second roll (or third for 10th frame) -->
                                    <input v-model="player.scores[frame - 1].roll2"
                                        @input="updateScore(playerIndex)"
                                        class="w-6 h-6 text-xs text-center border-none outline-none bg-transparent"
                                        maxlength="2" />
                                    <!-- Third roll for 10th frame only -->
                                    <input v-if="frame === 10" v-model="player.scores[frame - 1].roll3"
                                        @input="updateScore(playerIndex)"
                                        class="w-6 h-6 text-xs text-center border-none outline-none bg-transparent"
                                        maxlength="2" />
                                </div>
                                <!-- Frame total -->
                                <div class="text-xs mt-1 font-medium">
                                    {{ player.frameTotals[frame - 1] || '' }}
                                </div>
                            </td>

                            <!-- Total Score -->
                            <td class="border border-gray-800 p-2 text-center font-bold bg-yellow-50">
                                {{ player.totalScore }}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>