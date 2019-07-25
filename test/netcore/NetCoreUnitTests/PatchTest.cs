using Superstring;
using System;
using Xunit;

namespace NetCoreUnitTests
{
    public class PatchTest
    {
        [Fact]
        public void HonorsTheMergeAdjacentChangesOptionSetToFalse()
        {
            var patch = new Patch(mergeAdjacentChanges: false);

            patch.splice((row: 0, column: 10), (row: 0, column: 0), (row: 1, column: 5));
            patch.splice((row: 1, column: 5), (row: 0, column: 2), (row: 0, column: 8));

            Assert.Equal<Patch>(
                JSON.parse(JSON.stringify(patch.getChanges())),
                [
                  {
                    oldStart: (row: 0, column: 10),
                    oldEnd: (row: 0, column: 10),
                    newStart: (row: 0, column: 10),
                    newEnd: (row: 1, column: 5)
                  },
                  {
                    oldStart: (row: 0, column: 10),
                    oldEnd: (row: 0, column: 12),
                    newStart: (row: 1, column: 5),
                    newEnd: (row: 1, column: 13)
                  }
                ]);

            patch.delete();
        }
    }
}
