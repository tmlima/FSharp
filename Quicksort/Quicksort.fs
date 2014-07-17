// Learn more about F# at http://fsharp.net

module Quicksort

let rec quicksort = function
   | [] -> []                         
   | first::rest -> 
        let smaller,larger = List.partition ((>=) first) rest 
        List.concat [quicksort smaller; [first]; quicksort larger]

//If the list is empty, there is nothing to do.
//Otherwise: 
//  1. Take the first element of the list
//  2. Find all elements in the rest of the list that 
//      are less than the first element, and sort them. 
//  3. Find all elements in the rest of the list that 
//      are >= than the first element, and sort them
//  4. Combine the three parts together to get the final result: 
//      (sorted smaller elements + firstElement + 
//       sorted larger elements)       

//let rec quick = function
//    | [] -> []
//    | fi