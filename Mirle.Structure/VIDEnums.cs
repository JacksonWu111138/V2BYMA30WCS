namespace Mirle.Structure.Info
{
    public class VIDEnums
    {
        public enum ZoneType
        {
            Shelf = 1,
            Port = 2,
            Other = 3,
            HandOff = 9,
        }
        public enum CarrierState
        {
            WaitIn = 1,
            Transferring = 2,
            Completed = 3,
            Alternate = 4,
            WaitOut = 5,
            Installed = 6,
        }
        public enum ControlState
        {
            equipmentOffline = 1,
            goingToOffline = 2,
            hostOffline = 3,
            onlineLocal = 4,
            onlineRemote = 5,
        }

        public enum CraneTransferState
        {
            CraneOutOfService = 1,
            CraneInService = 2,
        }

        public enum CarrierType
        {
            UNKNOWN,
            STANDARD_HALF,
            STANDARD_FULL,
        }

        public enum ALCD
        {
            NotUsed = 0,
            PersonalSafety = 1,
            EquipmentSafety = 2,
            ParameterControlWarning = 3,
            ParameterControlError = 4,
            IrrecoverableError = 5,
            EquipmentStatusWarning = 6,
            AttentionFlags = 7,
            DataIntegrity = 8,
        }

        public enum CommandType
        {
            CANCEL,
            ABORT,
            TRANSFER,
        }

        public enum DisabledStatus
        {
            Enabled = 0,
            Disabled = 1,
        }

        public enum ShelfState
        {
            //Reporting Priority: 2,3 > 0,1
            Empty = 0,
            Occupied = 1,
            ProhibitedShelf = 2,
            ReservedShelf = 3,
        }

        public enum EqPresenceStatus
        {
            NoPresence = 0,
            Presence = 1,
        }

        public enum EqReqStatus
        {
            NoREQ = 0,
            LoadREQ = 1,
            UnloadREQ = 2,
        }

        public enum ErrorId
        {
            /// <summary>
            /// DoubleStore
            /// </summary>
            DestOccupied,

            /// <summary>
            /// EmptyRetrieve
            /// </summary>
            SourceEmpty,
            None,
        }

        public enum HandoffType
        {
            Manual = 1,
            Automated = 2,
        }

        public enum IDReadStatus
        {
            Successful = 0,
            Failure = 1,
            Duplicate = 2,
            Mismatch = 3,
            NoCarrier = 4,
        }

        public enum MainteState
        {
            Undefine = 0,
            Maintenance = 1,
            NotMaintenance = 2,
        }

        public enum PortTransferState
        {
            OutOfService = 1,
            InService = 2,
        }

        public enum PortType
        {
            OP,
            BP,
            LP,
        }

        public enum PortUnitType
        {
            Input = 0,
            Output = 1,
            Changing = 2,
        }

        public enum RCMD
        {
            RESUME,
            CANCEL,
            PAUSE,
            SCAN,
            PRIORITYUPDATE,
            PORTTYPECHG,
            ABORT,
            INSTALL,
            REMOVE,
            DISABLESHELF,
            ENABLESHELF,
            TRANSFER,
            TRANSFEREXT,
        }

        public enum RecoeryOption
        {
            RETRY_ABORT,
            None,
        }

        public enum ResultCode
        {
            Successful = 0,
            Unsuccessful = 1,
            AllBinLocationsOccupied = 2,
            IDDuplicate = 3,
            IDMismatch = 4,
            IDReadFailed = 5,
            InterlockError = 64,
        }

        public enum SCState
        {
            SCInit = 1,
            Paused = 2,
            Auto = 3,
            Pausing = 4,
        }

        public enum TransferState
        {
            None = 0,
            Queued = 1,
            Transferring = 2,
            Paused = 3,
            Canceling = 4,
            Aborting = 5,
        }

        public enum StockerUnitState
        {
            Normal = 0,
            DoubleStorage = 1,
            EmptyRetrieval = 2,
            ErrorUnit = 3,
            ErrorMode = 4,
        }

        public enum EmptyCarrier
        {
            Empty = 0,
            NotEmpty = 1,
        }

        public enum IDReadDuplicateOption
        {
            Reject = 0,
            HostControlled = 1,
        }

        public enum IDRFailuerOption
        {
            Reject = 0,
            HostControlled = 1,
        }

        public enum IDReadMismatchOption
        {
            Reject = 0,
            HostControlled = 1,
        }

        public enum CstSize
        {
            UnknownSize = 0,
            ATypeCSTNormal = 1,
            MaskCST = 2,
            MaskFlame = 3,
            ModuleCST = 4,
            ModuleTray = 5
        }

        public enum PauseReason
        {
            MCSRequest = 0,
            WorkOperation = 1,
            PeriodicalMaintenance = 2,
            ErrorRecovery = 3,
            OtherReason = 9,
        }
    }
}
