using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Sample : MonoBehaviour
{
    class Msg
    {
        public const short Text = MsgType.Highest + 1;
    }

    class Message : MessageBase
    {
        public string Text;
        // public string Text { get; set; } にするとうまく動かない
    }

    void Start()
    {
        // サーバがMsg.Textを受信したときに行う関数を登録する
        NetworkServer.RegisterHandler(Msg.Text, networkMessage =>
        {
            var mes = networkMessage.ReadMessage<Message>();
            Debug.Log(mes.Text);

            // Msg.Textを送ってきたクライアントに返信する
            networkMessage.conn.Send(Msg.Text, new Message() { Text = "Hello! from server" });
        });

        // サーバ開始
        // 他のコンピュータから接続したい場合は"0.0.0.0"などのIPを使用する
        NetworkServer.Listen("127.0.0.1", 7000);

        var client = new NetworkClient();

        // クライアントがMsg.Textを受信したときに行う関数を登録する
        client.RegisterHandler(Msg.Text, networkMessage =>
        {
            Debug.Log(networkMessage.ReadMessage<Message>().Text);
        });

        // クライアントがサーバに接続完了したときに行う関数を登録する
        client.RegisterHandler(MsgType.Connect, _ =>
        {
            // サーバにMsg.Textを送る
            client.Send(Msg.Text, new Message() { Text = "Hello!" });
        });

        // サーバに接続
        client.Connect("127.0.0.1", 7000);
    }
}
