module Combinatorics
open Operations

let combine n r = fat n / (fat(r)*fat(n-r))

let rec combineElementsIntoGrops (elementsQuantity:int) (groupSize:int) (groupQuantity:int) =
    if elementsQuantity < groupSize || groupQuantity < 1 
        then 1
    else
        combine elementsQuantity groupSize * combineElementsIntoGrops (elementsQuantity-groupSize) (groupSize) (groupQuantity-1)

let rec combineTwoElementsFixedSize (x:int) (y:int) (totalLenght:int) (xLenght:int) =
    combine x xLenght * combine y (totalLenght - xLenght)

let rec combineTwoElementsWithMinimum (x:int) (y:int) (r:int) (xMin:int) =
    if x = xMin
        then combine y (r - xMin)
    else if r = xMin
        then combine x r
    else
        combineTwoElementsFixedSize x y r xMin + combineTwoElementsWithMinimum x y r (xMin + 1)
    
let rec combineTwoElementsWithMinimumMaximum (x:int) (y:int) (r:int) (xMin:int) (xMax:int) =
    if xMin = xMax
        then combineTwoElementsFixedSize x y r xMax
    else
        combineTwoElementsFixedSize x y r xMax + combineTwoElementsFixedSize x y r (xMax-1)    