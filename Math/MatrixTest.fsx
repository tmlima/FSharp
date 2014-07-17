#r "FSharp.PowerPack.dll"

let a : matrix = matrix [[1.0; 0.0; -2.0]; [0.0;3.0;-1.0];]

let b : matrix = matrix [[0.0;3.0]; [-2.0;-1.0]; [0.0;4.0];]

let result: matrix = matrix [[0.0; -5.0]; [-6.0; -7.0];]

a * b = result