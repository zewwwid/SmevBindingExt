using System;
using System.ServiceModel.Dispatcher;

namespace CaptureBehavior
{
    /// <summary>
    /// Перехватчик сообщений.
    /// </summary>
    public class Inspector : IDispatchMessageInspector 
    {
        public string Request { get; set; }

        public string Response { get; set; }

        public event EventHandler<InspectorEventArgs> RaiseRequestReceived;

        public event EventHandler<InspectorEventArgs> RaiseSendingReply;

        protected void OnRaiseRequestReceived(string message)
        {
            var handler = RaiseRequestReceived;
            
            if (handler != null)
            {
                handler(this, new InspectorEventArgs(message));
            }
        }

        protected void OnRaiseSendingReply(string message)
        {
            var handler = RaiseSendingReply;

            if (handler != null)
            {
                handler(this, new InspectorEventArgs(message));
            }
        }

        #region IDispatchMessageInspector Members

        /// <summary>
        /// Вызывается при получении запроса.
        /// </summary>
        /// <param name="request">Сообщение</param>
        /// <param name="channel">Входящий канал</param>
        /// <param name="instanceContext">Текущий экземполяр службы</param>
        /// <returns></returns>
        public object AfterReceiveRequest(
            ref System.ServiceModel.Channels.Message request, 
            System.ServiceModel.IClientChannel channel, 
            System.ServiceModel.InstanceContext instanceContext)
        {
            Request = request.ToString();
            OnRaiseRequestReceived(Request);
            return null;
        }

        /// <summary>
        /// Вызывается после формирования ответа.
        /// </summary>
        /// <param name="reply">Ответное сообщение</param>
        /// <param name="correlationState">Объект корреляции</param>
        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, 
            object correlationState)
        {
            Response = reply.ToString();
            OnRaiseSendingReply(Response);
        }

        #endregion
    }
}
