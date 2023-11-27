using AuctionService.Data;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class BidPlacedConsumer : IConsumer<BidPlaced>
    {
        private readonly AuctionDbContext _dbcontext;
        public BidPlacedConsumer(AuctionDbContext dbcontext)
        {
             _dbcontext = dbcontext;
        }
        public async Task Consume(ConsumeContext<BidPlaced> context)
        {
            Console.Out.WriteLine("--> Consuming bid placed");

            var auctions = await _dbcontext.Auctions.FindAsync(context.Message.AuctionId);

            if(auctions.CurrentHighBid == null || context.Message.BidStatus.Contains("Accepted")
                && context.Message.Amount > auctions.CurrentHighBid)
            {
                auctions.CurrentHighBid = context.Message.Amount;
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
