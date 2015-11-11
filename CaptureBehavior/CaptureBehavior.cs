using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace CaptureBehavior
{
    /// <summary>
    /// Расширение функциональной службы для перехвата SOAP сообщений.
    /// </summary>
    public class CaptureBehavior : IServiceBehavior
    {
        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription, 
            System.ServiceModel.ServiceHostBase serviceHostBase, 
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, 
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            return;
        }

        /// <summary>
        /// Изменение свойст времени выполнения.
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, 
            System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            // Добавляем перехватчик сообщений
            foreach (var dispatcher in serviceHostBase.ChannelDispatchers.Cast<ChannelDispatcher>())
            {
                dispatcher.Endpoints
                    .ToList()
                    .ForEach(x => x.DispatchRuntime.MessageInspectors.Add(new Inspector()));
            }
        }

        public void Validate(ServiceDescription serviceDescription, 
            System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            return;
        }

        #endregion
    }
}
