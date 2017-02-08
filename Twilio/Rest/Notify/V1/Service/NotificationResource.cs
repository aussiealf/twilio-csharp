using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Notify.V1.Service 
{

    public class NotificationResource : Resource 
    {
        public sealed class PriorityEnum : StringEnum 
        {
            private PriorityEnum(string value) : base(value) {}
            public PriorityEnum() {}
        
            public static readonly PriorityEnum High = new PriorityEnum("high");
            public static readonly PriorityEnum Low = new PriorityEnum("low");
        }
    
        private static Request BuildCreateRequest(CreateNotificationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Notify,
                "/v1/Services/" + options.ServiceSid + "/Notifications",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Notification parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Notification </returns> 
        public static NotificationResource Create(CreateNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Notification parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Notification </returns> 
        public static async System.Threading.Tasks.Task<NotificationResource> CreateAsync(CreateNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="tag"> The tag </param>
        /// <param name="body"> The body </param>
        /// <param name="priority"> The priority </param>
        /// <param name="ttl"> The ttl </param>
        /// <param name="title"> The title </param>
        /// <param name="sound"> The sound </param>
        /// <param name="action"> The action </param>
        /// <param name="data"> The data </param>
        /// <param name="apn"> The apn </param>
        /// <param name="gcm"> The gcm </param>
        /// <param name="sms"> The sms </param>
        /// <param name="facebookMessenger"> The facebook_messenger </param>
        /// <param name="fcm"> The fcm </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Notification </returns> 
        public static NotificationResource Create(string serviceSid, List<string> identity = null, List<string> tag = null, string body = null, NotificationResource.PriorityEnum priority = null, int? ttl = null, string title = null, string sound = null, string action = null, string data = null, string apn = null, string gcm = null, string sms = null, object facebookMessenger = null, string fcm = null, ITwilioRestClient client = null)
        {
            var options = new CreateNotificationOptions(serviceSid){Identity = identity, Tag = tag, Body = body, Priority = priority, Ttl = ttl, Title = title, Sound = sound, Action = action, Data = data, Apn = apn, Gcm = gcm, Sms = sms, FacebookMessenger = facebookMessenger, Fcm = fcm};
            return Create(options, client);
        }
    
        #if NET40
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="tag"> The tag </param>
        /// <param name="body"> The body </param>
        /// <param name="priority"> The priority </param>
        /// <param name="ttl"> The ttl </param>
        /// <param name="title"> The title </param>
        /// <param name="sound"> The sound </param>
        /// <param name="action"> The action </param>
        /// <param name="data"> The data </param>
        /// <param name="apn"> The apn </param>
        /// <param name="gcm"> The gcm </param>
        /// <param name="sms"> The sms </param>
        /// <param name="facebookMessenger"> The facebook_messenger </param>
        /// <param name="fcm"> The fcm </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Notification </returns> 
        public static async System.Threading.Tasks.Task<NotificationResource> CreateAsync(string serviceSid, List<string> identity = null, List<string> tag = null, string body = null, NotificationResource.PriorityEnum priority = null, int? ttl = null, string title = null, string sound = null, string action = null, string data = null, string apn = null, string gcm = null, string sms = null, object facebookMessenger = null, string fcm = null, ITwilioRestClient client = null)
        {
            var options = new CreateNotificationOptions(serviceSid){Identity = identity, Tag = tag, Body = body, Priority = priority, Ttl = ttl, Title = title, Sound = sound, Action = action, Data = data, Apn = apn, Gcm = gcm, Sms = sms, FacebookMessenger = facebookMessenger, Fcm = fcm};
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns> 
        public static NotificationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The service_sid
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The identities
        /// </summary>
        [JsonProperty("identities")]
        public List<string> Identities { get; private set; }
        /// <summary>
        /// The tags
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; private set; }
        /// <summary>
        /// The priority
        /// </summary>
        [JsonProperty("priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        public NotificationResource.PriorityEnum Priority { get; private set; }
        /// <summary>
        /// The ttl
        /// </summary>
        [JsonProperty("ttl")]
        public int? Ttl { get; private set; }
        /// <summary>
        /// The title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }
        /// <summary>
        /// The body
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; private set; }
        /// <summary>
        /// The sound
        /// </summary>
        [JsonProperty("sound")]
        public string Sound { get; private set; }
        /// <summary>
        /// The action
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; private set; }
        /// <summary>
        /// The data
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; private set; }
        /// <summary>
        /// The apn
        /// </summary>
        [JsonProperty("apn")]
        public object Apn { get; private set; }
        /// <summary>
        /// The gcm
        /// </summary>
        [JsonProperty("gcm")]
        public object Gcm { get; private set; }
        /// <summary>
        /// The fcm
        /// </summary>
        [JsonProperty("fcm")]
        public object Fcm { get; private set; }
        /// <summary>
        /// The sms
        /// </summary>
        [JsonProperty("sms")]
        public object Sms { get; private set; }
        /// <summary>
        /// The facebook_messenger
        /// </summary>
        [JsonProperty("facebook_messenger")]
        public object FacebookMessenger { get; private set; }
    
        private NotificationResource()
        {
        
        }
    }

}