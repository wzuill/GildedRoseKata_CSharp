using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using ApprovalTests.Combinations;
using NUnit.Framework.Constraints;

namespace csharp
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
       //[Test]
//        public void ThirtyDays()
//        {
//            StringBuilder fakeoutput = new StringBuilder();
//            Console.SetOut(new StringWriter(fakeoutput));
//            Console.SetIn(new StringReader("a\n"));
//
//            Program.Main(new string[] { });
//            String output = fakeoutput.ToString();
//            Approvals.Verify(output);
//        }

        [Test]
        public void CharacterizationTest()
        {
            string[] names = {"foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros"};
            int[] sellIns = {-1, 0, 1, 2, 5, 6, 7, 10, 11, 12, 49, 50, 51};
            int[] qualitys = {-1, 0, 1, 2, 49, 50, 51};
            CombinationApprovals.VerifyAllCombinations(GetItem, names, sellIns, qualitys);

        }

        private string GetItem(string name, int sellIn, int quality)
        {
            Item[] items = {new Item {Name = name, Quality = quality, SellIn = sellIn}};
            new GildedRose(items).UpdateQuality();
            return items[0].ToString();
        }
    }
}
