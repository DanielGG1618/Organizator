using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types.InputFiles;

namespace Organizer
{
	static class Bot
	{
		static BackgroundWorker bw;

		public static void Initialize(string key)
		{
			bw = new BackgroundWorker();
			bw.DoWork += Bw_DoWork; // метод bw_DoWork будет работать асинхронно

			if (key != "" && bw.IsBusy != true)
			{
				bw.RunWorkerAsync(key); // передаем эту переменную в виде аргумента методу bw_DoWork
			}
		}

		private static async void Bw_DoWork(object sender, DoWorkEventArgs e)
		{
			var key = e.Argument as string; // получаем ключ из аргументов

			try
			{
				var Bot = new Telegram.Bot.TelegramBotClient(key); // инициализируем API
				await Bot.SetWebhookAsync("");
				//Bot.SetWebhook(""); // Обязательно! убираем старую привязку к вебхуку для бота
				int offset = 0; // отступ по сообщениям
				while (true)
				{
					var updates = await Bot.GetUpdatesAsync(offset); // получаем массив обновлений

					foreach (var update in updates) // Перебираем все обновления
					{
						var message = update.Message;
						if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
						{
							switch(message.Text)
							{
								case "/saysomething":
									await Bot.SendTextMessageAsync(message.Chat.Id, "something");
									break;

								case "/screen":
									if(Schelude.Screenshot == null)
                                    {
										await Bot.SendTextMessageAsync(message.Chat.Id, "скрин пуст, ткни Даниела");
										break;
									}

									using (Bitmap bitmap = Schelude.Screenshot)
									{
										bitmap.Save("C:/Windows/Temp/screen.jpg", ImageFormat.Jpeg);
									}
									const string screen = @"C:/Windows/Temp/screen.jpg";
									using (var fileStream = new FileStream(screen, FileMode.Open, FileAccess.Read, FileShare.Read))
									{
										await Bot.SendPhotoAsync(message.Chat.Id, new InputOnlineFile(fileStream));
									}
									break;
							}
						}
						offset = update.Id + 1;
					}
				}
			}
			catch (Telegram.Bot.Exceptions.ApiRequestException ex)
			{
				Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
			}
		}
	}
}