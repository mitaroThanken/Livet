using System;
using System.Collections.Generic;
using System.Text;

namespace Livet.Messaging
{
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
