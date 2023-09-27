namespace BlazorDemo.Services
{
    public class DashboardService
    {
        public IEnumerable<int> GetPoints()
        {
            var rand = new Random();
            var points = new List<int>();

            foreach (var i in Enumerable.Range(0, 10))
            {
                points.Add(rand.Next(0, 100));
            }

            return points;
        }

        public IEnumerable<int> GetCumulative()
        {
            var rand = new Random();
            var points = new List<int>();
            var prev = 0;

            foreach (var i in Enumerable.Range(0, 10))
            {
                var point = rand.Next(0, 100) + prev;
                prev = point;
                points.Add(point);
            }

            return points;
        }
    }
}
