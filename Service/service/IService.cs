using System.Net.Security;
using System.ServiceModel;

namespace Service
{
    [ServiceContract(Namespace = "http://smev.gosuslugi.ru/rev120315", Name = "SmevBindingExtSevice",
        ProtectionLevel = ProtectionLevel.Sign)]
    [XmlSerializerFormat]
    public interface IService
    {
        [OperationContract]
        [XmlSerializerFormat]
        Response DoWork(Request request);
    }

    /// <summary>
    /// Входящее сообщение.
    /// </summary>
    [MessageContract(WrapperName = "TestRequest")]
    [XmlSerializerFormat]
    public class Request
    {
        /// <summary>
        /// Cлужебный блок атрибутов СМЭВ.
        /// </summary>
        [MessageBodyMember(Name = "Message", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageType Message;

        /// <summary>
        /// Блок-обертка данных СМЭВ.
        /// </summary>
        [MessageBodyMember(Name = "MessageData", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageDataType MessageData;
    }

    /// <summary>
    /// Исходящее сообщение.
    /// </summary>
    [MessageContract(WrapperName = "TestResponse")]
    [XmlSerializerFormat]
    public class Response
    {
        /// <summary>
        /// Cлужебный блок атрибутов СМЭВ.
        /// </summary>
        [MessageBodyMember(Name = "Message", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageType Message;

        /// <summary>
        /// Блок-обертка данных СМЭВ.
        /// </summary>
        [MessageBodyMember(Name = "MessageData", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public MessageDataType MessageData;
    }
}
