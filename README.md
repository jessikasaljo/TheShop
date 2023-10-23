# TheShop

Kommentarer till programmet:

1. Jag arbetar på Mac och inställningen på min dator när programmet har kört färdigt är att det stängs ner så fort det har kört klart, vilket innebär att användaren inte har tid att läsa de sista meddelandena som står. Jag har därför lagt till en Console.ReadLine() i slutet av programmet så att man hinner läsa färdigt innan man avslutar helt.

2. När ens ShoppingCart skrivs ut är det en grej jag hade velat fixa. Har man lagt till flera items av samma vara, t.ex. att man har lagt till en banan två gånger, så skrivs det ut som
1 banana
1 banana

Jag hade velat ändra så att, istället för att det blir två separata objekt i listan slogs de ihop och det kunde stå
2 bananas

istället. Men det kändes för krångligt för min nuvarande kunskapsnivå, särskilt med tanke på att pluralversionen av de olika varorna inte alltid lägger till ett s på slutet av ordet (t.ex. flera "loaf of bread" blir ju "loaves of bread").