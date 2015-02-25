using Windows.UI.Xaml;

namespace Livet.Messaging
{
    /// <summary>
    /// 情報をViewに通知するためのメッセージです。
    /// </summary>
    public class InformationMessage : InteractionMessage
    {
        public InformationMessage()
        {
        }

        /// <summary>
        /// 表示するメッセージ・キャプション・メッセージキーを指定して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="text">表示するメッセージ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="messageKey">メッセージキー</param>
        public InformationMessage(string text, string caption, string messageKey) : base(messageKey)
        {
            Text = text;
            Caption = caption;
            MessageKey = messageKey;
        }

        /// <summary>
        /// 表示するメッセージ・キャプション・メッセージボックスイメージ・メッセージキーを指定して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="text">表示するメッセージ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="image">メッセージボックスイメージ</param>
        /// <param name="messageKey">メッセージキー</param>
        public InformationMessage(string text, string caption, MessageBoxImage image, string messageKey)
            : base(messageKey)
        {
            Text = text;
            Caption = caption;
            MessageKey = messageKey;
            Image = image;
        }

        // TODO 親が Freezable クラスからの派生ではなくなったため、削除。……大丈夫？
        /*
        /// <summary>
        /// 派生クラスでは必ずオーバーライドしてください。Freezableオブジェクトとして必要な実装です。<br/>
        /// 通常このメソッドは、自身の新しいインスタンスを返すように実装します。
        /// </summary>
        /// <returns>自身の新しいインスタンス</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new InformationMessage(Text,Caption,MessageKey);
        }
         */

        /// <summary>
        /// 表示するメッセージを指定、または取得します。
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(InformationMessage), new PropertyMetadata(null));

        /// <summary>
        /// キャプションを指定、または取得します。
        /// </summary>
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(InformationMessage), new PropertyMetadata(null));


        /// <summary>
        /// メッセージボックスイメージを指定、または取得します。
        /// </summary>
        public MessageBoxImage Image
        {
            get { return (MessageBoxImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(MessageBoxImage), typeof(InformationMessage), 
                new PropertyMetadata(MessageBoxImage.Information));

        /// <summary>
        /// メッセージ ボックスで表示されるアイコンを指定します。
        /// </summary>
        /// <remarks>
        /// System.Windows.MessageBoxImage 相当 (ユニバーサルアプリでは無効)
        /// </remarks>
        public enum MessageBoxImage
        {
            // 概要:
            //     アイコンは表示されません。
            None = 0,
            //
            // 概要:
            //     メッセージ ボックスに、背景が赤の円で囲まれた白い X から成る記号を表示します。
            Error = 16,
            //
            // 概要:
            //     メッセージ ボックスに、背景が赤の円で囲まれた白い X から成る記号を表示します。
            Hand = 16,
            //
            // 概要:
            //     メッセージ ボックスに、背景が赤の円で囲まれた白い X から成る記号を表示します。
            Stop = 16,
            //
            // 概要:
            //     メッセージ ボックスに、円で囲まれた疑問符から成る記号を表示します。
            Question = 32,
            //
            // 概要:
            //     メッセージ ボックスに、背景が黄色の三角形で囲まれた感嘆符から成る記号を表示します。
            Exclamation = 48,
            //
            // 概要:
            //     メッセージ ボックスに、背景が黄色の三角形で囲まれた感嘆符から成る記号を表示します。
            Warning = 48,
            //
            // 概要:
            //     メッセージ ボックスに、円で囲まれた小文字の i から成る記号を表示します。
            Information = 64,
            //
            // 概要:
            //     メッセージ ボックスに、円で囲まれた小文字の i から成る記号を表示します。
            Asterisk = 64,
        }
    }
}