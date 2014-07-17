using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFSharpMethods
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void TestJuros()
        {
            Decimal valor = 100M;
            Decimal juros = 10M;
            int periodo = 2;

            Decimal fjs = Operations.jurosSimples(valor, juros, periodo);
            Decimal fjc = Operations.jurosCompostos(valor, juros, periodo);
            Decimal cjs = MathCSharp.Math.JurosSimples(valor, juros, periodo);
            Decimal cjc = MathCSharp.Math.JurosCompostos(valor, juros, periodo);

            Assert.AreEqual(fjs, cjs);
            Assert.AreEqual(fjc, cjc);
        }

        [TestMethod]
        public void TestCombine()
        {
            Assert.AreEqual(MathCSharp.Combinatorics.Combine(6, 3), 20);
            Assert.AreEqual(MathCSharp.Combinatorics.Combine(6, 5), 6);
            Assert.AreEqual(MathCSharp.Combinatorics.Combine(10, 5), 252);
        }

        [TestMethod]
        public void TestCombineTwoElementsWithMinimum()
        {
            /*
             *  De um total de 6 pratos à base de carboidratos e 4 pratos à base de proteínas, 
             *  pretendo fazer o meu prato com 5 destes itens, itens diferentes, 
             *  de sorte que contenha ao menos 2 proteínas. 
             *  Qual é o número máximo de pratos distintos que poderei fazer? 
             */
            int result = 186;
            Assert.AreEqual(MathCSharp.Combinatorics.CombineTwoElementsWithMinimum(4, 6, 5, 2), result);
            Assert.AreEqual(Combinatorics.combineTwoElementsWithMinimum(4, 6, 5, 2), result);
        }

        [TestMethod]
        public void TestCombineTwoElementsWithMinimumMaximum()
        {
            /*
             * Em um refeitório há doces e salgados. 
             * Cada pessoa receberá um recipiente com 3 doces, dos 8 tipos disponíveis 
             * e apenas 2 salgados, dos 7 tipos fabricados. 
             * Quantas são as diferentes possibilidades de preenchimento do recipiente?
             */
            int result = 1176;
            Assert.AreEqual(MathCSharp.Combinatorics.CombineTwoElementsWithMinimumMaximum(8, 7, 5, 3, 3), result);
            Assert.AreEqual(Combinatorics.combineTwoElementsWithMinimumMaximum(8, 7, 5, 3, 3), result);
        }

        [TestMethod]
        public void TestCombineElementsIntoGroups()
        {
            /*
             * Oito pessoas irão acampar e levarão quatro barracas. 
             * Em cada barraca dormirão duas pessoas. 
             * Quantas são as opções de distribuição das pessoas nas barracas?
             */
            int result = 2520;
            Assert.AreEqual(MathCSharp.Combinatorics.CombineElementsIntoGroups(8, 2, 4), result);
            Assert.AreEqual(Combinatorics.combineElementsIntoGrops(8, 2, 4), result);
        }

        [TestMethod]
        public void TestesFat()
        {
            TestSapateira();
            TestClubes();
        }

        private void TestSapateira()
        {
            /*
             * Em uma sapateira irei guardar 3 sapatos, 2 chinelos e 5 tênis. 
             * Quantas são as disposições possíveis desde que os calçados de mesmo tipo fiquem juntos, 
             * lado a lado na sapateira?
             */

            int result = MathCSharp.Math.Fat(3) * MathCSharp.Math.Fat(2) * MathCSharp.Math.Fat(5) * MathCSharp.Math.Fat(3);
            Assert.AreEqual(result, 8640);
        }

        private void TestClubes()
        {
            /*
             * Grêmio (RS), Flamengo (RJ), Internacional (RS) e São Paulo (SP) disputam um campeonato.
             * Levando-se em conta apenas a unidade da federação de cada um dos clubes, 
             * de quantas maneiras diferentes pode terminar o campeonato?
             */

            int TeamsQuantity = 4;
            int TeamsFromRS = 2;
            int resultByTeam = MathCSharp.Math.Fat(TeamsQuantity);
            int resultByState = resultByTeam / TeamsFromRS;

            Assert.AreEqual(resultByState, 12);
        }
    }
}
