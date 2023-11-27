using AuctionService.Data;
using AuctionService.Entities;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
    {
        private readonly AuctionDbContext _dbcontext;
        public AuctionFinishedConsumer(AuctionDbContext dbcontext)
        {
            _dbcontext = dbcontext;    
        }
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            Console.Out.WriteLine("--> Consuming auction finished");

            var auctions = await _dbcontext.Auctions.FindAsync(context.Message.AuctionId);

            if (context.Message.ItemSold)
            {
                auctions.Winner = context.Message.Winner;
                auctions.SoldAmount = context.Message.Amount;
            }

            auctions.Status = auctions.SoldAmount > auctions.ReservePrice ? Status.Finished : Status.ReserveNotMet;

            await _dbcontext.SaveChangesAsync();
        }
    }
}
