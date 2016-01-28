using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.CSharp.WebUI.Views.Home;
using System.Collections.Generic;

namespace GildedRose.CSharp.WebUI.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void itemDegradaCalidadUnaUnidad()
        {
            //throw new ArgumentException("errorrrr");

            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();
       
            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Elixir of the Mongoose");
            int expectedQuality = actualItem.Quality - 1;
            
            
            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Elixir of the Mongoose");
            actualQuality = actualItem.Quality;

            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);
            
        }

        private Item BuscarItem(List<Item> items, string nombreItem)
        {
            bool itemEncontrado = false;
            int i = 0;
            Item result = null;

            while (!(itemEncontrado))
            {

                if (items[i].Name == nombreItem)
                {
                    itemEncontrado = true;
                    result = items[i];
                }
                i++;

            }
            return result;
        }

        [TestMethod]
        public void itemCaducadoDegradaDobleVelocidad()
        {
            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();

            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Elixir of the Mongoose");
            actualItem.SellIn = 0;
            int expectedQuality = actualItem.Quality - 2;

            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Elixir of the Mongoose");
            actualQuality = actualItem.Quality;
    

            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);
        }

        [TestMethod]
        public void itemCalidadNoNegativa()  /* he modificat el gildedroseadminpanel el valor de elixir a quality = 1 */
        {
            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();

            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Elixir of the Mongoose");
            actualItem.SellIn = 0;
            int expectedQuality = 0;

            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Elixir of the Mongoose");
            actualQuality = actualItem.Quality;


            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);

        }

        [TestMethod]
        public void itemEspecialIncrementaCalidad() /* error incrementa 2 unidades en vez de 1 */
        {
            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();

            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Aged Brie");
            actualItem.SellIn = -2;
            int expectedQuality = actualItem.Quality + 1;

            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Aged Brie");
            actualQuality = actualItem.Quality;


            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);


        }

        [TestMethod]
        public void itemCalidadNoSuperiorA50() /* REVISAR!!!! */
        {
            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();

            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Sulfuras, Hand of Ragnaros");
            actualItem.SellIn = 0;
            int expectedQuality = actualItem.Quality - 2;

            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Sulfuras, Hand of Ragnaros");
            actualQuality = actualItem.Quality;


            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);

        }

        [TestMethod]
        public void itemEspecialNoDisminuyeCalidad() /* REVISAR!!!!! */
        {
            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();

            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Sulfuras, Hand of Ragnaros");
            actualItem.SellIn = 0;
            int expectedQuality = actualItem.Quality;

            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Sulfuras, Hand of Ragnaros");
            actualQuality = actualItem.Quality;


            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);

        }

        [TestMethod]
        public void itemEspecialIncrementaCalidadVariable() /* Entrades */
        {
            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();

            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Backstage passes to a TAFKAL80ETC concert");
            actualItem.SellIn = 10;
            int expectedQuality;
            expectedQuality = getCalidadItemEspecial(actualItem);

            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Backstage passes to a TAFKAL80ETC concert");
            actualQuality = actualItem.Quality;


            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);


        }

        private int getCalidadItemEspecial(Item actualItem)
        {
            if((actualItem.SellIn > 0) && (actualItem.SellIn <= 5))
            {
                return actualItem.Quality * 3;
            }
            else if ((actualItem.SellIn > 0) && (actualItem.SellIn <= 10))
            {
                return actualItem.Quality * 2;
            }
            else {
                return 0;
            }
        }

        [TestMethod]
        public void itemCalidadDisminuyeDobleRapido()
        {
            //ARRANGE
            GildedRoseAdminPanel sut = new GildedRoseAdminPanel();

            int actualQuality;
            Item actualItem;
            actualItem = BuscarItem(sut.Items, "Conjured Mana Cake");
            int expectedQuality = actualItem.Quality - 2;


            //ACT
            sut.UpdateQuality();

            actualItem = BuscarItem(sut.Items, "Conjured Mana Cake");
            actualQuality = actualItem.Quality;

            //ASSERT
            Assert.AreEqual(expectedQuality, actualQuality);
        }

    }


}
