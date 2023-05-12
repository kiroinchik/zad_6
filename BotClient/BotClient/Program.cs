using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using System.Net.Http;
using Microsoft.VisualBasic;
using Domain.Models;
using Newtonsoft.Json;

namespace BotClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //HttpClient client = new HttpClient();
            //var result = await client.GetAsync("https://localhost:7127/api/User");

            //Console.WriteLine(result);

            //var test = await result.Content.ReadAsStringAsync();
            //Console.WriteLine(test);

            //Product[] products = JsonConvert.DeserializeObject<Product[]>(test);
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.PId + " " + product.PName + " " + product.Price);
            //}


            var botClient = new TelegramBotClient("5962002469:AAF9UBAi9RhFMdkECXU8MXCgUOWGoXUeTNA");

            using CancellationTokenSource cts = new();

            //StartReceiving does not block the caller thread. Reseiving is done on the ThreadPool
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()// reseive all update types
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            //Send cansellation request to stop bot
            cts.Cancel();
        }


        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //ONLY PROCESS MESSAGE UPDATES
            if (update.Message is not { } message)
                return;
            // ONLY PROCESS TEXT MESSAGES
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;
            Console.WriteLine(chatId);

            if (message.Text == "Привет") //приветствие
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text:$"Здравствуйте {message.Chat.Username}",
                    cancellationToken: cancellationToken);
            }
            if (message.Text == "Фото") //фото
            {
               await botClient.SendPhotoAsync(
                    chatId: chatId,
                    //photo: "https://www.google.com/search?q=%D0%BA%D0%BE%D0%BD%D1%81%D1%82%D0%B0%D0%BD%D1%82%D0%B8%D0%BD+%D0%B3%D0%B5%D1%86%D0%B0%D1%82%D0%B8&rlz=1C1GCEU_ruRU1003RU1003&source=lnms&tbm=isch&sa=X&ved=2ahUKEwi5jd-u4N3-AhUMpIsKHW4rDWwQ_AUoAXoECAEQAw&biw=1920&bih=912&dpr=1#imgrc=g3zAt30JzwPwwM",
                    photo: "https://images.uznayvse.ru/main_catalog_image/p/images/celebs/2019/6/konstantin-getsati_big.jpg",
                    caption: "<b> Константин Гецати, побидитель 18 сезона Битвы экстрасенсов</b>. <i>Source</i>: <a href=\"https://uznayvse.ru/znamenitosti/biografiya-konstantin-gecati.html\">Узнать больше</a>",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
            }
            if (message.Text == "Видео") //видео
            {
                await botClient.SendVideoAsync(
                    chatId: chatId,
                    video: "https://rr4---sn-4g5ednz7.googlevideo.com/videoplayback?expire=1683298694&ei=JsVUZJGjHc3MigTP16noDQ&ip=181.215.182.136&id=o-ANygYAuYq2PTRs5i5lzHAUkfFBIMPMowwWWDw_dZu24R&itag=18&source=youtube&requiressl=yes&spc=qEK7BwQTSzrszZeD-a6ARv5cUWF_Fsw74IlZUW17xw&vprv=1&svpuc=1&mime=video%2Fmp4&ns=J4t0V-A6IcNYwzffB014Z20N&cnr=14&ratebypass=yes&dur=128.058&lmt=1681604268238749&fexp=24007246&c=WEB&txp=5319224&n=KxGfogl8UNLj-w&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cspc%2Cvprv%2Csvpuc%2Cmime%2Cns%2Ccnr%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRQIgNUjVBkOimKLts6QveHGc58hCzYC5o8suyyYUX9re8AMCIQC1iNA8CN98yPaGH2_D4vyXQmgwfmngXhUL8tK_kMnCvg%3D%3D&redirect_counter=1&rm=sn-q4fee77e&req_id=bbf0e5bb5434a3ee&cms_redirect=yes&cmsv=e&mh=BP&mip=94.29.124.119&mm=34&mn=sn-4g5ednz7&ms=ltu&mt=1683276765&mv=m&mvi=4&pl=18&lsparams=mh,mip,mm,mn,ms,mv,mvi,pl&lsig=AG3C_xAwRAIgTPYGhl0ybasyaP9EbDEN16HAO0_kkhxuFgGHDt83uIUCIASzXTrK-zJxDtwYiys6xHgUQ_pC1DQQ9KIGsD6MB7FI",
                    thumb: "https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg",
                    supportsStreaming: true,
                    cancellationToken: cancellationToken);
            }
            if (message.Text == "Стикер") //стикер
            {
                await botClient.SendStickerAsync(
                    chatId: chatId,
                    sticker: "CAACAgIAAxkBAAEgrDVkVMO254qNUmMEW5Et50yezgwtlQACezAAAj51IEpjPW3C_JHjGC8E",
                    cancellationToken: cancellationToken);
            }


            Console.WriteLine($"Resieved a '{messageText}' message in chat {chatId}.");

            //ECHO RECEIVED MESSAGE TEXT
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                cancellationToken: cancellationToken);

            if (message.Text == "Проверка")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Проверка: Ок!",
                    cancellationToken: cancellationToken);
            }
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram ApiError: \n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
