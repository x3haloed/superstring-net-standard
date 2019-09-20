namespace Superstring
{
    public class MarkerIndex
    {
        private readonly uint _id;
        private readonly uint _seed;

        public MarkerIndex(uint seed = 0u)
        {
            _id = 0;    // TODO: Need to figure out algorithm for assigning IDs.
            _seed = seed;
        }

        public int GenerateRandomNumber(int p1) => WasmManager.Exports._ZN11MarkerIndex22generate_random_numberEv(p1);
        public void Insert(uint markerId, Point start, Point end) => WasmManager.Exports._ZN11MarkerIndex6insertEj5PointS0_(markerId, start, end);
    }
}
