import { FrameScore, Game, Roll } from '../types'


export const calculateScores = (game: Game): FrameScore[] => {
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