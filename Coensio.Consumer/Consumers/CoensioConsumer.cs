namespace Coensio.Consumer.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;

    using Coensio.Contract;
    using Coensio.Contexts;

    public class CoensioConsumer : IConsumer<TestCalculationEvent>
    {
        private readonly TestContext dbContext;
        public CoensioConsumer(TestContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Consume(ConsumeContext<TestCalculationEvent> context)
        {
            var id = context.Message.Id;

            var test = dbContext.Tests.Where(t => t.Id == id).FirstOrDefault();
            if (test is not null)
            {
                var codingQuestionAnswers = dbContext.CodingQuestionUserAnswers.Where(a => a.TestId == id).ToList();
                var freeTextQuestionAnswers = dbContext.FreeTextQuestionUserAnswers.Where(a => a.TestId == id).ToList();
                var multipleChoiceQuestionAnswers = dbContext.McqUserAnswers.Where(a => a.TestId == id).ToList();

                int sumCqa = codingQuestionAnswers.Select(a => a.Score).Sum();
                int sumFtqa = freeTextQuestionAnswers.Select(a => a.Score).Sum();
                int sumMcqa = multipleChoiceQuestionAnswers.Select(a => a.Score).Sum();

                test.Score = sumCqa + sumFtqa + sumMcqa;

                test.Status = "Score Calculated";
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("invalid test id");
            }
        }
    }
}