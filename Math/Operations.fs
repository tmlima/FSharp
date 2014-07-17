module Operations

let sum x y = x + y

let rec fat x = 
    if (x<1) then 1
    else x * fat(x-1)

let rec fibonacci x = 
    if x < 2 then x
    else fibonacci (x-1) + fibonacci (x-2)

let jurosDecimal (juros:decimal) : decimal = juros / 100M

let mult (a:decimal) (b:int) : decimal = a * decimal(b)

let rec pow (a:decimal) (b:decimal) : decimal = 
    match b with
    | 1M -> a
    | _ -> a * pow a (b-decimal(1))

let jurosSimples (valor:decimal) (juros:decimal) (periodo:int) : decimal= valor + (jurosDecimal(juros) * decimal(periodo))

let jurosCompostos (valor:decimal) (juros:decimal) (periodo:int) : decimal = valor * pow (1M + jurosDecimal juros) (decimal(periodo))
