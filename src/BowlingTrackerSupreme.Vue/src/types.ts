export type Roll = number

export interface Frame {
  rolls: Roll[] // 1–3 rolls depending on 10th frame
}

export interface Game {
  frames: Frame[] // always length 10
}

export interface FrameScore {
  frameIndex: number
  score: number | null
  runningTotal: number | null
}