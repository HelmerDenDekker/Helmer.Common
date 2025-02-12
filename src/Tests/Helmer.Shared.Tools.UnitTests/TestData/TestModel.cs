using System.ComponentModel.DataAnnotations;

namespace Helmer.Shared.Tools.UnitTests.TestData;

public class TestModel
{
	[Required]
	public string Name { get; set; }
}
