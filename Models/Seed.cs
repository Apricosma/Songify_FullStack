using Songify_FullStack.Data;

namespace Songify_FullStack.Models
{
    public class Seed
    {
        public async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new SongifyContext(serviceProvider.GetRequiredService<SongifyContext>());


        }
    }
}
