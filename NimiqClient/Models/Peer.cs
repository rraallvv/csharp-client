﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nimiq.Models
{
    /// <summary>Peer address state returned by the server.</summary>
    [Serializable]
    public enum PeerAddressState
    {
        /// <summary>New peer.</summary>
        @new = 1,
        /// <summary>Established peer.</summary>
        established = 2,
        /// <summary>Already tried peer.</summary>
        tried = 3,
        /// <summary>Peer failed.</summary>
        failed = 4,
        /// <summary>Balled peer.</summary>
        banned = 5
    }

    /// <summary>Peer connection state returned by the server.</summary>
    [Serializable]
    public enum PeerConnectionState
    {
        /// <summary>New connection.</summary>
        @new = 1,
        /// <summary>Connecting.</summary>
        connecting = 2,
        /// <summary>Connected.</summary>
        connected = 3,
        /// <summary>Negotiating connection.</summary>
        negotiating = 4,
        /// <summary>Connection established.</summary>
        established = 5,
        /// <summary>Connection closed.</summary>
        closed = 6
    }

    /// <summary>Commands to change the state of a peer.</summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumerationConverter))]
    public class PeerStateCommand : StringEnumeration
    {
        /// <summary>Connect.</summary>
        [JsonStringValue("connect")]
        public static PeerStateCommand Connect;
        /// <summary>Disconnect.</summary>
        [JsonStringValue("disconnect")]
        public static PeerStateCommand Disconnect;
        /// <summary>Ban.</summary>
        [JsonStringValue("ban")]
        public static  PeerStateCommand Ban;
        /// <summary>Unban.</summary>
        [JsonStringValue("unban")]
        public static PeerStateCommand Unban;
    }

    /// <summary>Peer information returned by the server.</summary>
    [Serializable]
    public class Peer
    {
        /// <summary>Peer id.</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>Peer address.</summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
        /// <summary>Peer address state.</summary>
        [JsonPropertyName("addressState")]
        public PeerAddressState AddressState { get; set; }
        /// <summary>Peer connection state.</summary>
        [JsonPropertyName("connectionState")]
        public PeerConnectionState? ConnectionState { get; set; }
        /// <summary>Node version the peer is running.</summary>
        [JsonPropertyName("version")]
        public int? Version { get; set; }
        /// <summary>Time offset with the peer (in miliseconds).</summary>
        [JsonPropertyName("timeOffset")]
        public int? TimeOffset { get; set; }
        /// <summary>Hash of the head block of the peer.</summary>
        [JsonPropertyName("headHash")]
        public string HeadHash { get; set; }
        /// <summary>Latency to the peer.</summary>
        [JsonPropertyName("latency")]
        public int? Latency { get; set; }
        /// <summary>Received bytes.</summary>
        [JsonPropertyName("rx")]
        public int? Rx { get; set; }
        /// <summary>Sent bytes.</summary>
        [JsonPropertyName("tx")]
        public int? Tx { get; set; }
    }
}
