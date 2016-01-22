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

    }


}
