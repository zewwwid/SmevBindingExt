using System.ServiceModel;

namespace Service
{
    [ServiceContract]
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
        /// Служебный загловок СМЭВ.
        /// </summary>
        [MessageHeader(Name = "Header", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public HeaderType Header;

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
        /// Служебный загловок СМЭВ.
        /// </summary>
        [MessageHeader(Name = "Header", Namespace = "http://smev.gosuslugi.ru/rev120315")]
        public HeaderType Header;

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
