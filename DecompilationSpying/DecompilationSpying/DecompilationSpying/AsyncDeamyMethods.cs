using System.Threading.Tasks;

namespace DecompilationSpying
{
    public class AsyncDeamyMethods
    {
        public void Initilize()
        {
            Task.Delay(1000).Wait();
        }
        public async void Init()
        {
            Task.Delay(1000).Wait();
        }

        /// <summary>
        /// Somewheres the far far away. Run starts new thread.
        /// </summary>
        public async void SomewhereFarFarAway()
        {
            Task.Run(() => Task.Delay(1000).Wait());
        }
    }
}
