using System;
using System.Windows;
using System.Windows.Input;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
namespace Psychological_diagnosis_system.ViewModels
{
    class StylePopupWindowAction : PopupWindowAction
    {
        private Window _wrapperWindow;
        /// <summary>
        /// 通过重写PopupWindowAction中的GetWindow方法，设置Window的Style属性。
        /// 否则打开的只能是默认窗体，无法设置样式。
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        protected override Window GetWindow(INotification notification)
        {
            if (this.WindowContent != null)
            {
                //初始化窗口
                _wrapperWindow = new Window
                {
                    //数据上下文
                    DataContext = notification,
                    Title = notification.Title,
                    //宽高自适应 内容
                    SizeToContent = SizeToContent.WidthAndHeight,

                };

                _wrapperWindow.KeyDown += WrapperWindow_KeyDown;
                ResourceDictionary langRd = null;
                try
                {
                    //读取资源文件(样式)
                    langRd = Application.LoadComponent(new Uri("/WindowAction/BorderlessWindow.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
                }
                catch
                {
                }
                //判断资源是否 读取成功.读取成功则不为null
                if (langRd != null)
                {
                    //判断是否已经有资源. 如果有 就 clear;
                    if (_wrapperWindow.Resources.MergedDictionaries.Count > 0)
                    {
                        _wrapperWindow.Resources.MergedDictionaries.Clear();
                    }
                    //将资源加入到window中
                    _wrapperWindow.Resources.MergedDictionaries.Add(langRd);
                }
                //将传入的 notification  放入 window
                PrepareContentForWindow(notification, _wrapperWindow);
            }
            else
            {
                //如果WindowContent 等于null  则 生成默认窗口
                _wrapperWindow = this.CreateDefaultWindow(notification);
            }

            return _wrapperWindow;
        }

        /// <summary>
        /// 键盘按下 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WrapperWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //按下ESC 关闭窗口
            if (e.Key == Key.Escape)
            {
                _wrapperWindow.Close();
            }

        }
    }
}
