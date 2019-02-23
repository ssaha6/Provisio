using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleList;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;

namespace SampleList.Test
{
    [PexClass(typeof(SampleList.List))]
    [TestClass]
    public partial class ListTest
    {
        [PexMethod]
        public void CheckSample([PexAssumeNotNull]List l, int x)
        {
            PexObserve.ValueForViewing("$input_x", x);
            PexObserve.ValueForViewing("$input_Count", l.Count());

            AssumePrecondition.IsTrue( (l.Count() <= 1)  );
            
            int oldCount = l.Count();
            l.addToEnd(x);

            NotpAssume.IsTrue((oldCount + 1) == l.Count());
            PexAssert.IsTrue((oldCount + 1) == l.Count());
        } 
    }
}
