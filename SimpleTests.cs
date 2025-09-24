using NUnit.Framework;

namespace SpecFlowRepro;

[TestFixture]
public class SimpleTests
{
    [Test]
    public void PlainNUnitPasses()
    {
        Assert.That(2 + 2, Is.EqualTo(4));
    }
}
