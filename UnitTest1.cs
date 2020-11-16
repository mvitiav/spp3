using AssemblyParserLibrary;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void constructor_TyPeTest()
        {
            TP tp = new TP();
            Assert.AreNotEqual(null,tp);
        }
        [Test]
        public void Constructor2_TyPeTest()
        {
            TP tp = new TP(typeof(string));
            Assert.AreNotEqual(null, tp);
        }

        [Test]
        public void setType_TyPeTest()
        {
            TP tp = new TP();
            string s = "";
            tp.setType(s.GetType());
            Assert.AreEqual(typeof(string),tp.type);
            //Assert.Pass();
        }

        [Test]
        public void addMT_TyPeTest()
        {
            TP tp = new TP();
            Assert.AreEqual(0, tp.methods.Count);
            tp.addMT(tp.GetType().GetMethods()[0]);
            Assert.AreEqual(1, tp.methods.Count);         
        }

        [Test]
        public void addFL_TyPeTest()
        {
            TP tp = new TP();
            Assert.AreEqual(0, tp.fields.Count);
            tp.addFL(tp.GetType().GetFields()[0]);
            Assert.AreEqual(1, tp.fields.Count);
        }

        [Test]
        public void addPR_TyPeTest()
        {
            TP tp = new TP();
            Assert.AreEqual(0, tp.props.Count);
            tp.addPR(typeof(string).GetProperties()[0]);
            Assert.AreEqual(1, tp.props.Count);
        }

   


        [Test]
        public void Constructor_PropertyTest()
        {
            PR pr = new PR(typeof(string).GetProperties()[0]);
            Assert.AreNotEqual(null, pr);
        }

        [Test]
        public void ToString_PropertyTest()
        {
            PR pr = new PR(typeof(string).GetProperties()[0]);
            Assert.AreEqual("[p]System.Char Chars", pr.ToString());
        }

        [Test]
        public void Constructor_NameSpaceTest()
        {
            NS ns = new NS(typeof(string).Namespace);
            Assert.AreNotEqual(null, ns);
        }

        [Test]
        public void addType_typeList__NameSpaceTest()
        {
          
            NS ns = new NS(typeof(string).Namespace);
            Assert.AreEqual(0,ns.getTypesList().Count);
            ns.addType(typeof(string));
            Assert.AreEqual(1, ns.getTypesList().Count);

            //Assert.Pass();
        }

        [Test]
        public void AddEverythingWithout_NameSpaceTest()
        {
            Assert.Pass();
        }

        [Test]
        public void AddOneProp_NameSpaceTest()
        {
            NS ns = new NS(typeof(string).Namespace);
            Assert.AreEqual(0, ns.getTypesList().Count);
            ns.addMethod(typeof(string), typeof(string).GetMethods()[0]);
            Assert.AreNotEqual(null, ns.getTypesList()[0].methods[0]);           
        }


        [Test]
        public void Constructor_MeThodTest()
        {
            MT mt = new MT(typeof(string).GetMethods()[0]);
            Assert.AreNotEqual(null, mt);
        }

        [Test]
        public void ToString_MeThodTest()
        {
            MT mt = new MT(typeof(string).GetMethods()[0]);
            Assert.AreEqual("[m]System.String Replace(String oldValue String newValue )", mt.ToString());
        }


        [Test]
        public void Constructor_FieldTest()
        {
            FL fl = new FL(typeof(string).GetFields()[0]);
            Assert.AreNotEqual(null, fl);
        }
        [Test]
        public void ToString_FieldTest()
        {
            FL fl = new FL(typeof(string).GetFields()[0]);
            Assert.AreEqual("[f]System.String Empty", fl.ToString());
        }


        [Test]
        public void Constructor_MainTest()
        {
            Library lib = new Library(@"G:\SPP\3\consoleTest\obj\Debug\netcoreapp3.1\consoleTest.dll");
            Assert.AreNotEqual(null, lib);
        }
        [Test]
        public void Extensions_MainTest()
        {

            Assembly asm = Assembly.LoadFrom(@"G:\SPP\3\consoleTest\obj\Debug\netcoreapp3.1\consoleTest.dll");
            Library lib = new Library(@"G:\SPP\3\consoleTest\obj\Debug\netcoreapp3.1\consoleTest.dll");
            var a = lib.checkIfHasExtensions(asm.GetTypes().ElementAt(1).GetTypeInfo());
            Assert.AreEqual(1, a.Count);
        }
        [Test]
        public void Crit_MainTest()
        {
            Library lib = new Library(@"G:\SPP\3\consoleTest\obj\Debug\netcoreapp3.1\consoleTest.dll");
            lib.processAsm();
            Assert.AreEqual(2, lib.getNsList().Count);
            Assert.AreEqual(2, lib.getNsList()[0].types.Count);
            Assert.AreEqual(4, lib.getNsList()[0].types.Values.ToList()[0].fields.Count);
            
        }
     
    }
}