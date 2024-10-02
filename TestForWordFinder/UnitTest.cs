using WordFinder;
namespace TestForWordFinder
{
    public class Tests
    {
        [Test]
        public void TestMoreThan64Rows()
        {
            List<string> listForMatrix = new List<string>();
            for(int i= 0; i < 69; i++) // more than 64 rows are created
            {
                listForMatrix.Add("eddededefefegagdfdghtyhjukuefewfefrggtrhyjuykruykiulkyunythythhy");
            }

            var ex = Assert.Throws<Exception>(() => new WordFinder.WordFinder(listForMatrix));
            Assert.That(ex.Message, Is.EqualTo("Invalid matrix size"));
        }

        [Test]
        public void TestMatrixWithDifferentRowsAndColumns()
        {
            List<string> listForMatrix = new List<string>();
            for (int i = 0; i < 35; i++) // create a matrix with valid sizes
            {
                listForMatrix.Add("eddededefefegagdfdghtyhjukuefewfefrggtrhyjuykruykiulkyunythythhy"); //64 chars
            }

            var ex = Assert.Throws<Exception>(() => new WordFinder.WordFinder(listForMatrix));
            Assert.That(ex.Message, Is.EqualTo("Invalid matrix size"));
        }


        [Test]
        public void TestValidMatrixSize()
        {
            List<string> listForMatrix = new List<string>();
            for (int i = 0; i < 64; i++)
            {
                listForMatrix.Add("eddededefefegagdfdghtyhjukuefewfefrggtrhyjuykruykiulkyunythythjj");
            }

            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);
            Assert.NotNull(wf);
        }

        [Test]
        public void TestDifferentRowsLength()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldc");
            listForMatrix.Add("fgwioddddd");
            listForMatrix.Add("chill");
            listForMatrix.Add("pqndd");
            listForMatrix.Add("uvdxy");

            var ex = Assert.Throws<Exception>(() => new WordFinder.WordFinder(listForMatrix));
            Assert.That(ex.Message, Is.EqualTo("Invalid matrix size"));
        }

        [Test]
        public void TestMatrixFiveRowsAndColumns()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldc");
            listForMatrix.Add("fgwio");
            listForMatrix.Add("chill");
            listForMatrix.Add("pqnsd");
            listForMatrix.Add("uvdxy");
            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            List<string> listForSearch = new List<string>();
            listForSearch.Add("cold");
            listForSearch.Add("wind");
            listForSearch.Add("snow");
            listForSearch.Add("chill");

            var resultList = wf.Find(listForSearch);

            Assert.That("cold", Is.EqualTo(resultList.FirstOrDefault()));
        }


        [Test]
        public void TestRepeatedWord()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldc"); // cold 2 ocurrencies
            listForMatrix.Add("fgwio");
            listForMatrix.Add("chill"); // chill 1 ocurrency
            listForMatrix.Add("pqnsd");
            listForMatrix.Add("uvdxy");
            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            // as chill is repeated several times, it is going to be counted as one
            List<string> listForSearch = new List<string>();
            listForSearch.Add("cold");
            listForSearch.Add("cold");
            listForSearch.Add("snow");
            listForSearch.Add("chill");
            listForSearch.Add("chill");
            listForSearch.Add("chill");
            listForSearch.Add("chill");
            listForSearch.Add("chill");
            listForSearch.Add("chill");

            var resultList = wf.Find(listForSearch);

            Assert.That("cold", Is.EqualTo(resultList.FirstOrDefault())); // cold is on top because 2 ocurrencies
        }

       

       

        [Test]
        public void TestNotFoundWords()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldc");
            listForMatrix.Add("fgwio");
            listForMatrix.Add("chill");
            listForMatrix.Add("pqnsd");
            listForMatrix.Add("uvdxy");
            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            List<string> listForSearch = new List<string>();
            listForSearch.Add("star");
            listForSearch.Add("mind");
            listForSearch.Add("shop");
            listForSearch.Add("eyes");

            var resultList = wf.Find(listForSearch);
            Assert.That(0, Is.EqualTo(resultList.Count()));
        }

        [Test]
        public void TestHorizontalAndVerticalWords()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("dlocl"); //cold from right to left
            listForMatrix.Add("fgwdl");
            listForMatrix.Add("llhfi");
            listForMatrix.Add("pqnhh");
            listForMatrix.Add("uvdcc"); //chill from bottom to top
            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            List<string> listForSearch = new List<string>();
            listForSearch.Add("cold");
            listForSearch.Add("chill");
            listForSearch.Add("shop");
            listForSearch.Add("eyes");

            var resultList = wf.Find(listForSearch);
            Assert.That(0, Is.EqualTo(resultList.Count()));
        }

        [Test]
        public void TestMatrixTenRowsAndColumns()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldcfgwio");
            listForMatrix.Add("fgwiopqnsd");
            listForMatrix.Add("chilluvdxy");
            listForMatrix.Add("pqnsdcoldc");
            listForMatrix.Add("uvdxyddddd");
            listForMatrix.Add("thtsdddgwd");
            listForMatrix.Add("uvdxydddid");
            listForMatrix.Add("windgqerng");
            listForMatrix.Add("juiytkredf");
            listForMatrix.Add("hbvfrewind");
            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            List<string> listForSearch = new List<string>();
            listForSearch.Add("cold");
            listForSearch.Add("wind");
            listForSearch.Add("snow");
            listForSearch.Add("chill");
            listForSearch.Add("wind");
            listForSearch.Add("ball");
            listForSearch.Add("cars");

            var resultList = wf.Find(listForSearch);

            Assert.That("wind", Is.EqualTo(resultList.FirstOrDefault()));
        }

        [Test]
        public void TestMatrixTwentyRowsAndColumns()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldcfgwiouvdxydddid");
            listForMatrix.Add("fgwiopqnsdjuiytkredf");
            listForMatrix.Add("chilluvdxythtsdddgwd");
            listForMatrix.Add("pqnsdcoldcfedaerfgth");
            listForMatrix.Add("uvdxydddddsdfretghyj");
            listForMatrix.Add("thtsdddgwdjuiytkredf");
            listForMatrix.Add("uvdxydddidpqnsdcoldc");
            listForMatrix.Add("windgqerngfgwiopqnsd");
            listForMatrix.Add("juiytkredfuvdxyddddd");
            listForMatrix.Add("hbvfrewindjuiytkredf");
            listForMatrix.Add("juiytkredfuvdxyddddd");
            listForMatrix.Add("buiytkredfuvdxyddddd");
            listForMatrix.Add("auiytkredfuvdxyddddd");
            listForMatrix.Add("luiytkredfuvdxyballd");
            listForMatrix.Add("luiytkredfuvdxyddddd");
            listForMatrix.Add("juiytkredfuvdxyddddc");
            listForMatrix.Add("juiytcredfuvdxyddddh");
            listForMatrix.Add("juiytoredfuvdxyddddi");
            listForMatrix.Add("juiytlredfuvdxyddddl");
            listForMatrix.Add("juiytdballusnowddddl");

            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            List<string> listForSearch = new List<string>();
            listForSearch.Add("cold"); //5
            listForSearch.Add("wind"); //4
            listForSearch.Add("snow"); //1
            listForSearch.Add("chill"); //2
            listForSearch.Add("wind"); //4
            listForSearch.Add("ball"); //3
            listForSearch.Add("cars"); //0

            var resultList = wf.Find(listForSearch);

            Assert.That("cold", Is.EqualTo(resultList.ToArray()[0]));
            Assert.That("wind", Is.EqualTo(resultList.ToArray()[1]));
            Assert.That("ball", Is.EqualTo(resultList.ToArray()[2]));
            Assert.That("chill", Is.EqualTo(resultList.ToArray()[3]));
            Assert.That("snow", Is.EqualTo(resultList.ToArray()[4]));

        }

        [Test]
        public void TestMatrixSixtyFourRowsAndColumns()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldcfgwiouvdxydddidfgwiopqnsdjuiytkredffgwiopqnsdjuiytkredffffh");
            listForMatrix.Add("fgwiopqnsdjuiytkredfbuiytkredfuvdxydddddbuiytkredfuvdxydddddgggh");
            listForMatrix.Add("chilluvdxythtsdddgwdjuiytkredfuvdxydddddjuiytkredfuvdxydddddgggh");
            listForMatrix.Add("pqnsdcoldcfedaerfgthuvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("uvdxydddddsdfretghyjuvdxydddddsdfretghyjuvdxydddddsdfretghyjjjjj");
            listForMatrix.Add("thtsdddgwdjuiytkredfuvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("uvdxydddidpqnsdcoldcuvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("windgqerngfgwiopqnsduvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("juiytkredfuvdxyddddduvdxydddddsdfretghyjffffuvdxydddddsdfretghyj");
            listForMatrix.Add("hbvfrewindjuiytkredfuvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("juiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("buiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("auiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjgggg");
            listForMatrix.Add("luiytkredfuvdxyballduvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("luiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("juiytkredfuvdxyddddcuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytcredfuvdxyddddhuvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("juiytoredfuvdxyddddiuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytlredfuvdxyddddluvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytdballusnowddddluvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");

            listForMatrix.Add("coldcfgwiouvdxydddidfgwiopqnsdjuiytkredffgwiopqnsdjuiytkredffffh");
            listForMatrix.Add("fgwiopqnsdjuiytkredfbuiytkredfuvdxydddddbuiytkredfuvdxydddddgggh");
            listForMatrix.Add("chilluvdxythtsdddgwdjuiytkredfuvdxydddddjuiytkredfuvdxydddddgggh");
            listForMatrix.Add("pqnsdcoldcfedaerfgthuvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("uvdxydddddsdfretghyjuvdxydddddsdfretghyjuvdxydddddsdfretghyjjjjj");
            listForMatrix.Add("thtsdddgwdjuiytkredfuvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("uvdxydddidpqnsdcoldcuvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("windgqerngfgwiopqnsduvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("juiytkredfuvdxyddddduvdxydddddsdfretghyjffffuvdxydddddsdfretghyj");
            listForMatrix.Add("hbvfrewindjuiytkredfuvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("juiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("buiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("auiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjgggg");
            listForMatrix.Add("luiytkredfuvdxyballduvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("luiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("juiytkredfuvdxyddddcuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytcredfuvdxyddddhuvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("juiytoredfuvdxyddddiuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytlredfuvdxyddddluvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytdballusnowddddluvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");

            listForMatrix.Add("coldcfgwiouvdxydddidfgwiopqnsdjuiytkredffgwiopqnsdjuiytkredffffh");
            listForMatrix.Add("fgwiopqnsdjuiytkredfbuiytkredfuvdxydddddbuiytkredfuvdxydddddgggh");
            listForMatrix.Add("chilluvdxythtsdddgwdjuiytkredfuvdxydddddjuiytkredfuvdxydddddgggh");
            listForMatrix.Add("pqnsdcoldcfedaerfgthuvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("uvdxydddddsdfretghyjuvdxydddddsdfretghyjuvdxydddddsdfretghyjjjjj");
            listForMatrix.Add("thtsdddgwdjuiytkredfuvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("uvdxydddidpqnsdcoldcuvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("windgqerngfgwiopqnsduvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("juiytkredfuvdxyddddduvdxydddddsdfretghyjffffuvdxydddddsdfretghyj");
            listForMatrix.Add("hbvfrewindjuiytkredfuvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("juiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjffff");
            listForMatrix.Add("buiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("auiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjgggg");
            listForMatrix.Add("luiytkredfuvdxyballduvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("luiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("juiytkredfuvdxyddddcuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytcredfuvdxyddddhuvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("juiytoredfuvdxyddddiuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytlredfuvdxyddddluvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytdballusnowddddluvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");

            listForMatrix.Add("luiytkredfuvdxyddddduvdxydddddsdfretghyjuvdxydddddsdfretghyjhhhh");
            listForMatrix.Add("juiytkredfuvdxyddddcuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");
            listForMatrix.Add("juiytcredfuvdxyddddhuvdxydddddsdfretghyjuvdxydddddsdfretghyjeeee");
            listForMatrix.Add("juiytoredfuvdxyddddiuvdxydddddsdfretghyjuvdxydddddsdfretghyjrrrr");


            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            List<string> listForSearch = new List<string>();
            listForSearch.Add("cold"); //11
            listForSearch.Add("wind"); //8
            listForSearch.Add("snow"); //3
            listForSearch.Add("chill"); //4
            listForSearch.Add("wind"); //8
            listForSearch.Add("ball"); //7
            listForSearch.Add("cars"); //0

            var resultList = wf.Find(listForSearch);

            Assert.That("cold", Is.EqualTo(resultList.ToArray()[0]));
            Assert.That("wind", Is.EqualTo(resultList.ToArray()[1]));
            Assert.That("ball", Is.EqualTo(resultList.ToArray()[2]));
            Assert.That("chill", Is.EqualTo(resultList.ToArray()[3]));
            Assert.That("snow", Is.EqualTo(resultList.ToArray()[4]));

        }


        [Test]
        public void TestTopTenWords()
        {
            List<string> listForMatrix = new List<string>();
            listForMatrix.Add("coldcfgwiouvdxydcold");
            listForMatrix.Add("fgwiopqnsdjuiytkredf");
            listForMatrix.Add("chilluvdxythtsdddgwd");
            listForMatrix.Add("pqnsdcoldcfedaerfgth");
            listForMatrix.Add("uvdxydddddsdfretghyj");
            listForMatrix.Add("thtsdddgwdjuiytkredf");
            listForMatrix.Add("uvdxydddidpqnsdcoldc");
            listForMatrix.Add("windgqerngfgwiopqnsd");
            listForMatrix.Add("juiytkredfuvdxyddddd");
            listForMatrix.Add("hbvfrewindjuiytkredf");
            listForMatrix.Add("juiytkredfuvdxydroad");
            listForMatrix.Add("buiytkredfuvdxyddddd");
            listForMatrix.Add("starskredfuvdxyddddd");
            listForMatrix.Add("luiytsignfuvdxyballd");
            listForMatrix.Add("luiykroadfuvdxyddddd");
            listForMatrix.Add("juiytkredfuvdxyddddc");
            listForMatrix.Add("carstcredfuvdxyddddh");
            listForMatrix.Add("juimoonedfuvdxyddddi");
            listForMatrix.Add("juiytlredfuvdxyddddl");
            listForMatrix.Add("juiytdballusnowdmany");

            WordFinder.WordFinder wf = new WordFinder.WordFinder(listForMatrix);

            List<string> listForSearch = new List<string>();
            listForSearch.Add("cold"); //6
            listForSearch.Add("wind"); //4
            listForSearch.Add("snow"); //1
            listForSearch.Add("chill"); //2
            listForSearch.Add("wind"); //4
            listForSearch.Add("ball"); //3
            listForSearch.Add("cars"); //1

            listForSearch.Add("many"); //1
            listForSearch.Add("sign"); //1
            listForSearch.Add("stars"); //1
            listForSearch.Add("road"); //2
            listForSearch.Add("child"); //0
            listForSearch.Add("moon"); //1
            listForSearch.Add("wall"); //0


            var resultList = wf.Find(listForSearch);
            string[] res = resultList.ToArray();

            Assert.That("cold", Is.EqualTo(resultList.ToArray()[0]));
            Assert.That("wind", Is.EqualTo(resultList.ToArray()[1]));
            Assert.That("ball", Is.EqualTo(resultList.ToArray()[2]));
            Assert.That("road", Is.EqualTo(resultList.ToArray()[3]));
            Assert.That("cars", Is.EqualTo(resultList.ToArray()[4]));
            Assert.That("chill", Is.EqualTo(resultList.ToArray()[5]));
            Assert.That("many", Is.EqualTo(resultList.ToArray()[6]));
            Assert.That("moon", Is.EqualTo(resultList.ToArray()[7]));
            Assert.That("sign", Is.EqualTo(resultList.ToArray()[8]));
            Assert.That("snow", Is.EqualTo(resultList.ToArray()[9]));

        }


    }
}