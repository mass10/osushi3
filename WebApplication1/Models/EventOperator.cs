using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Net.Http;
using CoreTweet;

namespace WebApplication1.Models
{
    public sealed class EventOperator
    {
        private string replyToken = "";
        private string request_signature = "";
        private string signature = "";

        public EventOperator(Newtonsoft.Json.Linq.JObject eventObject, string request_signature, string signature)
        {
            this.request_signature = request_signature;
            this.signature = signature;

            string type = "" + eventObject["type"];
            string replyToken = "" + eventObject["replyToken"];
            this.replyToken = replyToken;
            if (type == "message")
            {
                // メッセージを受信した
                this.handleMessageText(eventObject["message"]);
            }
            else if (type == "follow")
            {
                // フォロー再開した(友だち追加ではない)
            }
            else
            {

            }
        }

        private void replyTextMessage(string messageText)
        {
            System.Collections.IList messages = new System.Collections.ArrayList();
			
			// メッセージ文字列
			{
				var message_data = new System.Collections.SortedList();
                message_data["type"] = "text";
                message_data["text"] = messageText;
                messages.Add(message_data);
            }

            // リプライ
            {
				var content = new Dictionary<string, object>();
				content["replyToken"] = this.replyToken;
				content["messages"] = messages;
				string json = Newtonsoft.Json.JsonConvert.SerializeObject(content);
                var request_body = new StringContent(json, Encoding.UTF8, "application/json");
                var authorization = String.Format("Bearer {0}", Constants.CHANNEL_ACCESS_TOKEN);
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", authorization);
                client.PostAsync("https://api.line.me/v2/bot/message/reply", request_body);
            }
        }

        private void replyTextMessageWithImage(string messageText, string imageUrl)
        {
            System.Collections.IList messages = new System.Collections.ArrayList();

            // メッセージ文字列
            {
                var message_data = new System.Collections.SortedList();
                message_data["type"] = "text";
                message_data["text"] = messageText;
                messages.Add(message_data);
            }

            // 絵を付ける
            {
                var message_data = new System.Collections.SortedList();
                message_data["type"] = "image";
                message_data["originalContentUrl"] = imageUrl;
                message_data["previewImageUrl"] = imageUrl;
                messages.Add(message_data);
            }

            // リプライ
            {
				var content = new Dictionary<string, object>();
				content["replyToken"] = this.replyToken;
				content["messages"] = messages;
				string json = Newtonsoft.Json.JsonConvert.SerializeObject(content);
                var request_body = new StringContent(json, Encoding.UTF8, "application/json");
                var authorization = String.Format("Bearer {0}", Constants.CHANNEL_ACCESS_TOKEN);
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", authorization);
                client.PostAsync("https://api.line.me/v2/bot/message/reply", request_body);
            }
        }

        private void handleMessageText(Newtonsoft.Json.Linq.JToken messageObject)
        {
            string messageType = "" + messageObject["type"];
            if (messageType == "text")
            {
				// ========== テキストメッセージへの自動返信 ==========
				string s = "" + messageObject["text"];
                if (s.Contains("かずのこ"))
                {
                    this.replyTextMessage("かずのこたべたい...");
                }
                else if (s.Contains("こもちこんぶ"))
                {
                    this.replyTextMessage("こもちこんぶたべたい...");
                }
                else if (s.Contains("ほたて"))
                {
                    this.replyTextMessage("ほたてたべたい...");
                }
                else if (s.Contains("かき"))
                {
                    this.replyTextMessage("かきたべたい...");
                }
                else if (s.Contains("いかのしおから"))
                {
                    this.replyTextMessage("いかのしおからたべたい...");
                }
                else if (s.Contains("しおから"))
                {
                    this.replyTextMessage("しおからたべたい...");
                }
                else if (s.Contains("ばくらい"))
                {
                    this.replyTextMessageWithImage("ばくらいたべたい...", "https://s3-ap-northeast-1.amazonaws.com/085d921e-3fb9-4d4c-8b4b-e66d36b50614/osushibot-images/bakurai.jpg");
                }
                else if (s.Contains("おしんこ"))
                {
                    this.replyTextMessageWithImage("おしんこたべたい...", "https://s3-ap-northeast-1.amazonaws.com/085d921e-3fb9-4d4c-8b4b-e66d36b50614/osushibot-images/oshinko.jpg");
                }
                else if (s.Contains("なまこ"))
                {
                    this.replyTextMessage("なまこたべたい...");
                }
                else if (s.Contains("たいらがい"))
                {
                    this.replyTextMessage("たいらがいたべたい...");
                }
                else if (s.Contains("あかがい"))
                {
                    this.replyTextMessage("あかがいたべたい...");
                }
                else if (s.Contains("はまぐり"))
                {
                    this.replyTextMessage("はまぐりたべたい...");
                }
                else if (s.Contains("ほっきがい"))
                {
                    this.replyTextMessage("ほっきがいたべたい...");
                }
                else if (s.Contains("いくら"))
                {
                    this.replyTextMessage("いくらたべたい...");
                }
                else if (s.Contains("からすみ"))
                {
                    this.replyTextMessage("からすみたべたい...");
                }
                else if (s.Contains("すじこ"))
                {
                    this.replyTextMessage("すじこたべたい...");
                }
                else if (s.Contains("たまご"))
                {
                    this.replyTextMessage("たまごたべたい...");
                }
                else if (s.Contains("はまち"))
                {
                    this.replyTextMessage("はまちたべたい...");
                }
                else if (s.Contains("がり"))
                {
                    this.replyTextMessageWithImage("がりたべたい...", "https://s3-ap-northeast-1.amazonaws.com/osushijp/images/gari.jpg");
                }
                else if (s.Contains("ぶり"))
                {
                    this.replyTextMessage("ぶりたべたい...");
                }
                else if (s.Contains("すずき"))
                {
                    this.replyTextMessage("すずきたべたい...");
                }
                else if (s.Contains("ごちそうさま"))
                {
                    this.replyTextMessageWithImage("はいまいど～", "https://osushijp.blob.core.windows.net/osushibot-images/ocha.jpg");
                }
                else if (s.Contains("おかんじょう"))
                {
                    this.replyTextMessageWithImage("はいまいど～", "https://osushijp.blob.core.windows.net/osushibot-images/ocha.jpg");
                }
                else if (s.Contains("かんじょう"))
                {
                    this.replyTextMessageWithImage("はいまいど～", "https://osushijp.blob.core.windows.net/osushibot-images/ocha.jpg");
                }
                else if (s.Contains("きんめだい"))
                {
                    this.replyTextMessage("きんめだいたべたい...");
                }
                else if (s.Contains("かつお"))
                {
                    this.replyTextMessage("かつおたべたい...");
                }
                else if (s.Contains("ほや"))
                {
                    this.replyTextMessage("ほやたべたい...");
                }
                else if (s.Contains("くろだい"))
                {
                    this.replyTextMessage("くろだいたべたい...");
                }
                else if (s.Contains("いしだい"))
                {
                    this.replyTextMessage("いしだいたべたい...");
                }
                else if (s.Contains("たい"))
                {
                    this.replyTextMessageWithImage("たいたべたい...", "https://s3-ap-northeast-1.amazonaws.com/osushijp/images/tai.jpg");
                }
                else if (s.Contains("まだい"))
                {
                    this.replyTextMessageWithImage("まだいたべたい...", "https://s3-ap-northeast-1.amazonaws.com/osushijp/images/tai.jpg");
                }
                else if (s.Contains("かんぱち"))
                {
                    this.replyTextMessage("かんぱちたべたい...");
                }
                else if (s.Contains("さより"))
                {
                    this.replyTextMessage("さよりたべたい...");
                }
                else if (s.Contains("ひらめ"))
                {
                    this.replyTextMessage("ひらめたべたい...");
                }
                else if (s.Contains("いわし"))
                {
                    this.replyTextMessage("いわしたべたい...");
                }
                else if (s.Contains("あじ"))
                {
                    this.replyTextMessage("あじたべたい...");
                }
                else if (s.Contains("たこ"))
                {
                    this.replyTextMessageWithImage("たこたべたい...", "https://s3-ap-northeast-1.amazonaws.com/osushijp/images/namatako.jpg");
                }
                else if (s.Contains("ひとで"))
                {
                    this.replyTextMessage("ひとでたべたい...");
                }
                else if (s.Contains("うに"))
                {
                    this.replyTextMessage("うにたべたい...");
                }
                else if (s.Contains("いか"))
                {
                    this.replyTextMessage("いかたべたい... http://ikacenter.com/");
                }
                else if (s.Contains("かれい"))
                {
                    this.replyTextMessage("かれいたべたい...");
                }
                else
                {
                    this.replyTextMessage("" + s + "なんかないよ");
                }
				// ========== 更新 ==========
				{
					PostT(s);
                }
            }
            else
            {
				// ========== 不明な種類のメッセージへの自動返信 ==========
				this.replyTextMessage("ちょっとやめてよ");
            }
        }

        private static readonly IDictionary<string, int> _counter = new Dictionary<string, int>();

        private static int increment_sakana(string key)
        {
            lock (_counter)
            {
                int current = 0;
                if (_counter.ContainsKey(key))
                {
                    current = _counter[key];
                }
                current++;
                _counter[key] = current;
                return current;
            }
        }

        private static void PostT(string text)
        {
			return;
            try
            {
                var tokens = CoreTweet.Tokens.Create(
                    "MtYzmMXPLZcCEZvwaXc3mamWz",
                    "FXHJD3JIkm4YFz737QdhV2jghtVklo0ezImzn06w7VJz9a99AB",
                    "943116199159783424-laSNeOdO3owQ79tbohVArtYS5tzSKdU",
                    "WkoiVQBKefJHCbbAY7NY6NdNc7ujZkXjgsU5rFwZKLm00");
                text = text + " #test #おすしのはちべえ";
                tokens.Statuses.Update(new { status = text });
            }
            catch
            {

            }
        }
    }
}

class Message
{
    private string _text = "";
    private string _image = "";

    public Message(string text)
    {
        this._text = text;
    }

    public Message(string text, string image)
    {
        this._text = text;
        this._image = image;
    }
}