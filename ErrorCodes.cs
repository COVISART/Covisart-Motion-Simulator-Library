

// ReSharper disable ObjectCreationAsStatement

using CovisartMotionSimulatorLibrary.Enum;

namespace CovisartMotionSimulatorLibrary
{
    /// <summary>
    /// Hata kodunu ve bilgisini tutan <see langword="class"/>
    /// </summary>
    public class ErrorCode
    {
        public ErrorCode(Dictionary<decimal, ErrorCode> list,decimal code, ErrorType type, string description)
        {
            Type = type;
            Description = description;

            list.Add(code, this);
        }

        public ErrorType Type { get; }
        public string Description { get; }
    }

    /// <summary>
    /// Plc'deki error kodların karşılığı. Bu error kodlarına aşağıdaki değişkenleri kullanarak ulaşabilirsiniz: 
    /// <see cref="Engine.AxisErrorId"/>,
    /// <see cref="Engine.ExactPositionErrorId"/>,
    /// <see cref="Engine.PowerErrorId"/>,
    /// <see cref="Engine.StopAxisErrorId"/>
    /// </summary>
    public class ErrorCodes : Dictionary<decimal, ErrorCode>
    {
        public Dictionary<decimal, ErrorCode> List;
        public ErrorCodes()
        {
            List = this;
            #region General NC Errors
            new ErrorCode(List,16384, ErrorType.Internal, @"""Internal error"" Internal system error in the NC on ring 0, no further details.");
            new ErrorCode(List,16385, ErrorType.Memory, @"""Memory error"" The ring-0 memory management is not providing the required memory. This is usually a result of another error, as a result of which the controller will halt normal operation (now if not before).");
            new ErrorCode(List,16386, ErrorType.Internal, @"""Nc retain data error (persistent data)"" Error while loading the Nc retain data. The axes concerned are no longer referenced (status flag ""Homed"" is set to FALSE).
Possible reasons are:
- Nc retain data not found
- Nc retain data expired (old backup data)
- Nc retain data corrupt or inconsistent");
            new ErrorCode(List,16400, ErrorType.Parameter, @"""Channel identifier not allowed"" Either an unacceptable value (not 1...255) has been used, or a channel that does not exist in the system has been named.");
            new ErrorCode(List,16401, ErrorType.Parameter, @"""Group identifier not allowed"" Either an unacceptable value (not 1...255) has been used, or a group that does not exist in the system has been named.");
            new ErrorCode(List,16402, ErrorType.Parameter, @"""Axis identifier not allowed"" Either an unacceptable value (not 1...255) has been used, or an axis that does not exist in the system has been named.");
            new ErrorCode(List,16403, ErrorType.Parameter, @"""Encoder identifier not allowed"" Either an unacceptable value (not 1...255) has been used, or a encoder that does not exist in the system has been named.");
            new ErrorCode(List,16404, ErrorType.Parameter, @"""Controller identifier not allowed"" Either an unacceptable value (not 1...255) has been used, or a controller that does not exist in the system has been named.");
            new ErrorCode(List,16405, ErrorType.Parameter, @"""Drive identifier not allowed"" Either an unacceptable value (not 1...255) has been used, or a drive that does not exist in the system has been named.");
            new ErrorCode(List,16406, ErrorType.Parameter, @"""Table identifier not allowed"" Either an unacceptable value (not 1...255) has been used, or a table that does not exist in the system has been named.");
            new ErrorCode(List,16416, ErrorType.Internal, @"""No process image"" No PLC-axis interface during creation of an axis.");
            new ErrorCode(List,16417, ErrorType.Internal, @"""No process image"" No axis-PLC interface during creation of an axis.");
            new ErrorCode(List,16418, ErrorType.Internal, @"""No process image"" No encoder-I/O interface during creation of an axis.");
            new ErrorCode(List,16419, ErrorType.Internal, @"""No process image"" No I/O-encoder interface during creation of an axis.");
            new ErrorCode(List,16420, ErrorType.Internal, @"""No process image"" No drive-I/O interface during creation of an axis.");
            new ErrorCode(List,16421, ErrorType.Internal, @"""No process image"" No I/O-drive interface during creation of an axis.");
            new ErrorCode(List,16432, ErrorType.Internal, @"""Coupling type not allowed"" Unacceptable master/slave coupling type.");
            new ErrorCode(List,16433, ErrorType.Internal, @"""Axis type not allowed"" Unacceptable type specification during creation of an axis.");
            new ErrorCode(List,16448, ErrorType.Internal, @"""Axis is incompatible"" Axis is not suitable for the intended purpose. A high speed/low speed axis, for example, cannot function as a slave in an axis coupling.");
            new ErrorCode(List,16464, ErrorType.Internal, @"""Channel not ready for operation"" The channel is not complete, and is therefore not ready for operation. This is usually a consequence of problems at system start-up.");
            new ErrorCode(List,16465, ErrorType.Internal, @"""Group not ready for operation"" The group is not complete, and is therefore not ready for operation. This is usually a consequence of problems at system start-up.");
            new ErrorCode(List,16466, ErrorType.Internal, @"""Axis not ready for operation"" The axis is not complete, and is therefore not ready for operation. This is usually a consequence of problems at system start-up.");
            new ErrorCode(List,16480, ErrorType.Internal, @"""Channel exists"" The channel that is to be created already exists.");
            new ErrorCode(List,16481, ErrorType.Internal, @"""Group exists"" The group that is to be created already exists.");
            new ErrorCode(List,16482, ErrorType.Internal, @"""Axis exists"" The axis that is to be created already exists.");
            new ErrorCode(List,16483, ErrorType.Internal, @"""Table exists"" The table that is to be created already exists, resp. it is tried internally to use an already existing table id ( e.g. for the universal flying saw).");
            new ErrorCode(List,16496, ErrorType.Internal, @"""Axis index not allowed"" The location within the channel specified for an axis is not allowed.");
            new ErrorCode(List,16497, ErrorType.Internal, @"""Axis index not allowed"" The location within the group specified for an axis is not allowed.");



            #endregion

            #region Channel Errors
            new ErrorCode(List,16641, ErrorType.Parameter, @"""Group index not allowed"" The location within the channel specified for a group is not allowed.");
            new ErrorCode(List,16642, ErrorType.Address, @"""Null, pointer"" The pointer to the group is invalid. This is usually a consequence of an error at system start-up.");
            new ErrorCode(List,16643, ErrorType.Internal, @"""No process image"" It is not possible to exchange data with the PLC. Possible causes: n the channel does not have an interface (no interpreter present) n The connection to the PLC is faulty");
            new ErrorCode(List,16644, ErrorType.Parameter, @"""M-function index not allowed"" Unacceptable M-function (not 0...159) detected at the execution level.");
            new ErrorCode(List,16645, ErrorType.Memory, @"""No memory"" No more system memory is available. This is usually the result of another error.");
            new ErrorCode(List,16646, ErrorType.Function, @"""Not ready"" The function is not presently available, because a similar function is already being processed. This is usually the result of access conflicts: more than one instance wants to issue commands to the channel. This can, for example, be the consequence of an incorrect PLC program.");
            new ErrorCode(List,16647, ErrorType.Function, @"""Function/command not supported"" A requested function or command is not supported by the channel.");
            new ErrorCode(List,16648, ErrorType.Parameter, @"""Invalid parameter while starting"" Parameters to start the channel (TwinCAT-Start) are invalid. Typically there is an invalid memory size or channel type requested.");
            new ErrorCode(List,16649, ErrorType.Function, @"""Channel function/command not executable"" A channel function e.g. interpreter start is not executable because the channel is already busy, no program is loaded or in an error state.");
            new ErrorCode(List,16650, ErrorType.Function, @"""ItpGoAhead not executable"" The requested command is not executable, because the interpreter is not executing a decoder stop.");
            new ErrorCode(List,16656, ErrorType.Parameter, @"""Error opening a file"" The specified file does not exist. Sample: NC program unknown.");
            new ErrorCode(List,16657, ErrorType.NcProgramming, @"""Syntax error during loading"" The NC has found a syntax error when loading an NC program.");
            new ErrorCode(List,16658, ErrorType.NcProgramming, @"""Syntax error during interpretation"" The NC has found a syntax error when executing an NC program.");
            new ErrorCode(List,16659, ErrorType.NcProgramming, @"""Missing subroutine"" The NC has found a missing subroutine while loading.");
            new ErrorCode(List,16660, ErrorType.Memory, @"""Loading buffer of interpreter is too small"" The capacity of the interpreter loading buffer has been exceeded.");
            new ErrorCode(List,16661, ErrorType.Internal, @"“Symbolic” - reserved");
            new ErrorCode(List,16662, ErrorType.Internal, @"“Symbolic” - reserved");
            new ErrorCode(List,16663, ErrorType.NcProgramming, @"""Subroutine incomplete"" Header of subroutine is missing");
            new ErrorCode(List,16664, ErrorType.NcProgramming, @"""Error while loading the NC program"" The maximum number of loadable NC programs has been reached.
Possible cause:
Too many sub-programs were loaded from a main program.");
            new ErrorCode(List,16665, ErrorType.NcProgramming, @"""Error while loading the NC program"" The program name is too long.");
            new ErrorCode(List,16672, ErrorType.NcProgramming, @"""Divide by zero"" The NC encountered a computation error during execution: division by 0.");
            new ErrorCode(List,16673, ErrorType.NcProgramming, @"""Invalid circle parameterization"" The NC encountered a computation error during execution: The specified circle cannot be calculated.");
            new ErrorCode(List,16674, ErrorType.NcProgramming, @"""Invalid FPU-Operation"" The NC encountered an invalid FPU-Operation during execution. This error occurs e.g. by calculating the square root of a negative number.");
            new ErrorCode(List,16688, ErrorType.NcProgramming, @"""Stack overflow: subroutines"" The NC encountered a stack overflow during execution: too many subroutine levels.");
            new ErrorCode(List,16689, ErrorType.NcProgramming, @"""Stack underflow: subroutines"" The NC encountered a stack underflow during execution: too many subroutine return commands. Note: A main program must not end with a return command.");
            new ErrorCode(List,16690, ErrorType.NcProgramming, @"""Stack overflow: arithmetic unit"" The NC encountered a stack overflow during execution: The calculation is too complex, or has not been correctly written.");
            new ErrorCode(List,16691, ErrorType.NcProgramming, @"""Stack underflow: arithmetic unit"" The NC encountered a stack underflow during execution: The calculation is too complex, or has not been correctly written.");
            new ErrorCode(List,16704, ErrorType.Parameter, @"""Register index not allowed"" The NC encountered an unacceptable register index during execution: Either the program contains an unacceptable value (not R0...R999) or a pointer register contains an unacceptable value.");
            new ErrorCode(List,16705, ErrorType.NcProgramming, @"""Unacceptable G-function index"" The NC has encountered an unacceptable G-function (not 0...159) during execution.");
            new ErrorCode(List,16706, ErrorType.NcProgramming, @"""Unacceptable M-function index"" The NC has encountered an unacceptable M-function (not 0...159) during execution.");
            new ErrorCode(List,16707, ErrorType.NcProgramming, @"""Unacceptable extended address"" The NC has encountered an unacceptable extended address (not 1...9) during execution.");
            new ErrorCode(List,16708, ErrorType.NcProgramming, @"""Unacceptable index to the internal H-function"" The NC has encountered an unacceptable internal H-function in the course of processing. This is usually a consequence of an error during loading.");
            new ErrorCode(List,16709, ErrorType.Parameter, @"""Machine data value unacceptable"" While processing instructions the NC has detected an impermissible value for the machine data (MDB) (not 0…7).");
            new ErrorCode(List,16720, ErrorType.Parameter, @"""Cannot change tool params here"" The NC has encountered an unacceptable change of parameters for the tool compensation during execution. This error occurred for instance by changing the tool radius and programming a circle in the same block.");
            new ErrorCode(List,16721, ErrorType.Parameter, @"""Cannot calculate tool compensation"" The NC has encountered an error by the calculation of the tool compensation.");
            new ErrorCode(List,16722, ErrorType.NcProgramming, @"Tool compensation: The plane for the tool compensation cannot be changed here. This error occurred for instance by changing the tool plane when the compensation is turned on or active.");
            new ErrorCode(List,16723, ErrorType.NcProgramming, @"Tool compensation: The D-Word is missing or invalid by turning on the tool compensation.");
            new ErrorCode(List,16724, ErrorType.NcProgramming, @"Tool compensation: The specified tool radius is invalid because the value is less or equal zero.");
            new ErrorCode(List,16725, ErrorType.NcProgramming, @"Tool compensation: The tool radius cannot be changed here");
            new ErrorCode(List,16726, ErrorType.Internal, @"Tool compensation: Collision Detection Table is full.");
            new ErrorCode(List,16727, ErrorType.Internal, @"Tool compensation: Internal error while turning on the contour collision detection.");
            new ErrorCode(List,16728, ErrorType.Internal, @"Tool compensation: Internal error within the contour collision detection: update reversed geo failed.");
            new ErrorCode(List,16729, ErrorType.NcProgramming, @"Tool compensation: Unexpected combination of geometry types by active contour collision detection.");
            new ErrorCode(List,16730, ErrorType.NcProgramming, @"Tool compensation: Programmed inner circle is smaller than the cutter radius");
            new ErrorCode(List,16731, ErrorType.NcProgramming, @"Tool compensation: Bottle neck detection recognized contour violation");
            new ErrorCode(List,16732, ErrorType.Memory, @"Table for corrected entries is full");
            new ErrorCode(List,16733, ErrorType.Memory, @"Input table for tangential following is full");
            new ErrorCode(List,16734, ErrorType.Memory, @"Executing table for tangential following is full");
            new ErrorCode(List,16735, ErrorType.Internal, @"Geometric entry for tangential following cannot be calculated");
            new ErrorCode(List,16736, ErrorType.Internal, @"reserved");
            new ErrorCode(List,16737, ErrorType.Internal, @"reserved");
            new ErrorCode(List,16738, ErrorType.Parameter, @"The actual active interpolation rules (g-code), zero-shifts, or rotation cannot be detected");
            new ErrorCode(List,16752, ErrorType.NcProgramming, @"""Error while loading: Invalid parameter"" The NC has found an invalid parameter while loading an NC program.");
            new ErrorCode(List,16753, ErrorType.Internal, @"""Invalid contour start position"" The NC encountered a computation error during execution: The specified contour cannot be calculated because the initial position is not on the contour.");
            new ErrorCode(List,16754, ErrorType.Internal, @"""Retrace: Invalid internal entry index"" The NC encountered an invalid internal entry index during execution of the retrace function.");


            #endregion

            #region Group Errors
            new ErrorCode(List,16896, ErrorType.Parameter, @"""Group ID not allowed""
The value for the group ID is not allowed, e.g. because it has already been assigned, is less than or equal to zero, or is greater than 255.");

            new ErrorCode(List,16897, ErrorType.Parameter, @"""Group type not allowed""
The value for the group type is unacceptable because it is not defined.
Type 1: PTP group with slaves (servo)
Type 4: DXD group with slaves (3D group)
Type 5: High/low speed group
Type 6: Stepper motor group
Type 9: Encoder group with slaves (servo)
…");

            new ErrorCode(List,16898, ErrorType.Initialization, @"""Master axis index not allowed"" The value for the master axis index in an interpolating 3D group is not allowed, because, for instance, it has gone outside the value range. Index 0: X axis (first master axis) Index 1: Y axis (second master axis) Index 2 : Z axis (third master axis)");

            new ErrorCode(List,16899, ErrorType.Initialization, @"""Slave axis index not allowed"" (INTERNAL ERROR) The value for the slave axis index in a group is not allowed, because, for instance, it has passed outside the value range, the slave location to be used when inserting a new slave connection is already occupied, or because no slave is present when such a connection is being removed. Index 0: First slave axis Index 1: Second slave axis Index 2: etc.");

            new ErrorCode(List,16900, ErrorType.Initialization, @"""INTERNAL ERROR"" (GROUPERR_INTERNAL)");
            new ErrorCode(List,16901, ErrorType.Parameter, @"""Invalid cycle time for statement execution task (SAF)"" The value of the cycle time for the NC block execution task (SAF 1/2) is not allowed, because it has passed outside the value range.");

            new ErrorCode(List,16902, ErrorType.Initialization, @"""GROUPERR_RANGE_MAXELEMENTSINAXIS """);
            new ErrorCode(List,16903, ErrorType.Parameter, @"""Invalid cycle time for the statement preparation task (SVB)"" The value of the cycle time for the NC statement preparation task (SVB 1/2) is not allowed, because it has passed outside the value range.");

            new ErrorCode(List,16904, ErrorType.Parameter, @"""Single step mode not allowed"" The flag for the activation or deactivation of single step mode is not allowed. Value 0: Passive (buffered operation) Value 1: Active (single-block operation)");

            new ErrorCode(List,16905, ErrorType.Parameter, @"""Group deactivation not allowed"" (INTERNAL ERROR) The flag for the deactivation or activation of the complete group is not allowed. Value 0: Group active Value 1: Group passive");

            new ErrorCode(List,16906, ErrorType.Initialization, @"""Statement execution state (SAF state) not allowed"" (INTERNAL ERROR) The value for the state of the block execution state machine (SAF state) is not allowed. This error occurs on passing outside the range of values, or if the state machine enters an error state.");

            new ErrorCode(List,16907, ErrorType.Address, @"""Channel address"" The group does not have a channel, or the channel address has not been initialized.");
            new ErrorCode(List,16908, ErrorType.Address, @"""Axis address (master axis)"" The group does not have a master axis (or axes) or the axis address(es) has (have) not been initialized.");
            new ErrorCode(List,16909, ErrorType.Address, @"""Master axis address"" A new master/slave coupling is to be inserted into the group, but there is no valid address for the leading master axis.");
            new ErrorCode(List,16910, ErrorType.Address, @"""Slave axis address"" A master/slave coupling is to be inserted into the group, but there is no valid address for the slave axis.");
            new ErrorCode(List,16911, ErrorType.Address, @"""Slave set value generator address"" A master/slave coupling is to be inserted into the group, but there is no valid address for the slave set value generator.");
            new ErrorCode(List,16912, ErrorType.Address, @"""Encoder address"" An axis in the group does not have an encoder, or the encoder address has not been initialized.");
            new ErrorCode(List,16913, ErrorType.Address, @"""Controller address"" An axis in the group does not have a controller, or the controller address has not been initialized.");
            new ErrorCode(List,16914, ErrorType.Address, @"""Drive address"" An axis in the group does not have a drive, or the drive address has not been initialized.");
            new ErrorCode(List,16915, ErrorType.Address, @"""GROUPERR_ADDR_MASTERGENERATOR""");
            new ErrorCode(List,16916, ErrorType.Address, @"""Axis interface NC to PLC address"" Group/axis does not have an axis interface from the NC to the PLC, or the axis interface address has not been initialized.");
            new ErrorCode(List,16917, ErrorType.Address, @"""Slave axis address"" An existing master/slave coupling is to be removed from the group, but there is no valid address for the slave axis.");
            new ErrorCode(List,16918, ErrorType.Address, @"""Table address unknown"" The table, respectively the table ID, is unknown. This table is used for the master/slave coupling or for the characteristic curve.");
            new ErrorCode(List,16919, ErrorType.Address, @"""NcControl address"" The NcControl address has not been initialized.");
            new ErrorCode(List,16920, ErrorType.Initialization, @"""Axis is blocked for commands while persistent NC data are queued"" Axis is blocked for commands while waiting for valid IO data to accept the queued persistent NC data.");
            new ErrorCode(List,16921, ErrorType.Function, @"""The scaling mode MASTER-AUTOOFFSET is invalid because no reference table was found"". The used scaling mode MASTER-AUTOOFFSET is invalid in this context because an existing reference table is missing.
This error can occur for example when adding cam tables without a unique reference to an existing cam table.");
            new ErrorCode(List,16922, ErrorType.Parameter, @"""The master axis start position does not permit synchronization"" When a slave axis is being coupled on, the position of the master axis does not permit synchronization at the given synchronization positions.");
            new ErrorCode(List,16923, ErrorType.Parameter, @"""Slave coupling factor (gearing factor) of 0.0 is not allowed"" A master/slave coupling with a gearing factor of 0.0 is being created. This value is not allowed, since it does not correspond to any possible coupling, and division will generate an FPU exception.");
            new ErrorCode(List,16924, ErrorType.Function, @"""Insertion of master axis into group not allowed"" A master axis is to be inserted into a group at a location that is already occupied by another master axis. Maybe the reconfiguration cannot be done, because this axis has got an existing slave coupling. This master/slave coupling must be revoked before.");
            new ErrorCode(List,16925, ErrorType.Function, @"""Deletion of master axis from group not allowed"" (INTERNAL ERROR) A master axis is to be removed from a location in a group that is not in fact occupied by master axis.");
            new ErrorCode(List,16926, ErrorType.Function, @"""Function/feature is not supported from the setpoint generator A function or feature is not supported from the setpoint generator (e.g. PTP master setpoint generator). This can be in general or only in a special situation.");
            new ErrorCode(List,16927, ErrorType.Initialization, @"""Group initialization"" Group has not been initialized. Although the group has been created, the rest of the initialization has not been performed (1. Initialization of group I/O, 2. Initialization of group, 3. Reset group).");
            new ErrorCode(List,16928, ErrorType.Monitoring, @"""Group not ready / group not ready for new task"" The group is being given a new task while it is still in the process of executing an existing task. This request is not allowed because it would interrupt the execution of the previous task. The new task could, for instance, be a positioning command, or the ""set actual position"" function. Precisely the converse relationships apply for the ""set new end position"" function. In that case, the group/axis must still be actively moving in order to be able to cause a change in the end position.");
            new ErrorCode(List,16929, ErrorType.Monitoring, @"""Requested set velocity is not allowed"" The value requested for the set velocity of a positioning task is less than or equal to zero, larger than the ""maximum velocity"" (see axis parameters), or, in the case of servo-drives, is larger than the ""reference velocity"" of the axis (see drive parameters).");
            new ErrorCode(List,16930, ErrorType.Monitoring, @"""Requested target position is not allowed (master axis)"" The requested value for the target position of a positioning task is not within the software end locations. In other words, it is either less than the minimum software end location or larger than the maximum software end location. This check is only carried out if the relevant end position monitoring is active.");
            new ErrorCode(List,16931, ErrorType.Monitoring, @"""No enable for controller and/or feed (Master axis)"" The axis enables for the master axis needed for positioning are not present. This can involve the controller enable and/or the relevant, direction-dependent feed enable (see axis interface PlcToNc).");
            new ErrorCode(List,16932, ErrorType.Monitoring, @"""Movement smaller than one encoder increment"" (INTERNAL ERROR) The distance that a group/axis is supposed to move is smaller than the physical significance of one encoder increment. In other words the movement is smaller than the scaling factor of the axis. The reaction to this is that the axis is reported as having logically finished without having actively moved. This means that an external error is not generated for the user. This error is also issued for high/low speed axes if a loop movement with nonzero parameters is smaller than the sum of the creeping and braking distances. In such a case it is not meaningful to either exceed or to fail to reach the target position.");
            new ErrorCode(List,16933, ErrorType.Monitoring, @"""Drive not ready during axis start"" During an axis start it is ascertained that the drive is not ready. The following are possible causes: - the drive is in the error state (hardware error) - the drive is in the start-up phase (e.g. after an axis reset that was preceded by a hardware error) - the drive is missing the controller enable (ENABLE) Note: The time required for ""booting"" a drive after a hardware fault can amount to several seconds.");
            new ErrorCode(List,16934, ErrorType.Monitoring, @"""Invalid parameters of the emergency stop."" Either, both, the deceleration and the jerk are less than zero or one of the parameters is weaker than the corresponding parameter of the start data.");
            new ErrorCode(List,16935, ErrorType.Function, @"""The setpoint generator is inactive such that no instructions are accepted.""");
            new ErrorCode(List,16936, ErrorType.Monitoring, @"""Requested traverse distance is not allowed"" The requested traverse distance or looping distance is smaller than the braking distance of the two/speed axis.");
            new ErrorCode(List,16937, ErrorType.Monitoring, @"""Requested target position is not allowed (slave axis)"" The value for the target position of a positioning task when calculated for the slave axis is not within the software end locations. In other words, it is either less than the minimum software end location or larger than the maximum software end location. This check is only carried out if the relevant end position monitoring is active.");
            new ErrorCode(List,16938, ErrorType.Monitoring, @"""No enable for controller and/or feed (slave axis)"" The axis enables for one or more coupled slave axes needed for positioning are not present. This can involve the controller enable and/or the relevant, direction-dependent feed enable (see axis interface PlcToNc).");
            new ErrorCode(List,16939, ErrorType.Parameter, @"""The activation position (position threshold) is out of range of the actual positioning"" The activation position (position threshold) of a new axis command (e.g. ""new velocity activated at a position"") is out of range. E.g. the activation position is before the actual position or behind the target position.");
            new ErrorCode(List,16940, ErrorType.Parameter, @"""The start or activation data of the external setpoint generation are not valid"" This may be caused through: 1. The external setpoint generation is active and a new activation with a start type (1: absolute, 2: relative) unequal to the current one is send.
2. The internal setpoint generation is active (e.g. PTP) and the external one is activated with the type absolute (two setpoint generators of the type absolute are not possible).");
            new ErrorCode(List,16941, ErrorType.Parameter, @"""Velocity is not constant"" For changing the dynamic parameter 'acceleration' und 'deceleration' the axis has to be in dynamic state without acceleration and deceleration (that means constant velocity).");
            new ErrorCode(List,16942, ErrorType.Parameter, @"""Jerk less than or equal to 0.0 is not allowed"" A value less than or equal to 0.0 for the jerk (PTP and CNC) is not allowed, since the jerk is by definition positive, and with a jerk of 0.0, division will generate an FPU exception.");
            new ErrorCode(List,16943, ErrorType.Parameter, @"""Acceleration less than or equal to 0.0 is not allowed"" A value less than or equal to 0.0 for the acceleration (PTP and CNC) is not allowed, since the acceleration is positive by definition, and an acceleration of 0.0 will not allow a motion to be generated.");
            new ErrorCode(List,16944, ErrorType.Parameter, @"""Absolute deceleration value less than or equal to 0.0 is not allowed"" A value less than or equal to 0.0 for the absolute value of the deceleration (PTP and CNC) is not allowed, since the absolute value of the deceleration is positive by definition, and an absolute value of the deceleration of 0.0 will not allow a motion to be generated.");
            new ErrorCode(List,16945, ErrorType.Parameter, @"""Set velocity less than or equal to 0.0 is not allowed"" A value less than or equal to 0.0 or outside the range from 10-3 up to 10+10 for the set velocity (PTP and CNC) is not allowed, since the set velocity is by definition strictly positive, and with a set velocity of 0.0, division will generate an FPU exception.");
            new ErrorCode(List,16946, ErrorType.Monitoring, @"""Loss of precision when trying a positioning"" The positioning is so long in space or time that decimal parts loose there relevance LOSS_OF_PRECISION).");
            new ErrorCode(List,16947, ErrorType.Parameter, @"""Cycle time less than or equal to 0.0 is not allowed"" A value less than or equal to 0.0 for the cycle time (PTP and CNC) is not allowed, since the cycle time is by definition strictly positive, and with a cycle time of 0.0, division will generate an FPU exception.");
            new ErrorCode(List,16948, ErrorType.Internal, @"""PTP data type <intasdouble> range exceeded"" Such extreme parameters have been supplied for the start task, the override or the new target position that the internal data type loses its precision.");
            new ErrorCode(List,16949, ErrorType.Function, @"""PTP LHL velocity profile cannot be generated"" (INTERNAL ERROR) Such extreme parameters have been supplied for the start task, the override or the new target position that it is not possible to generate a velocity profile of the type LHL (Low-High-Low).");
            new ErrorCode(List,16950, ErrorType.Function, @"""PTP HML velocity profile cannot be generated"" (INTERNAL ERROR) Such extreme parameters have been supplied for the override or the new target position that it is not possible to generate a velocity profile of the type HML (High-Middle-Low).");
            new ErrorCode(List,16951, ErrorType.Address, @"""Start data address is invalid"" The address of the start data is invalid.");
            new ErrorCode(List,16952, ErrorType.Parameter, @"""Velocity override (start override) is not allowed"" The value for the velocity override is not allowed, because it is less than 0.0% or more than 100.0% (see axis interface PlcToNc). Here, 100.0 % corresponds to the integral value 1000000 in the axis interface. Value range: [0 ... 1000000]");
            new ErrorCode(List,16953, ErrorType.Parameter, @"""Start type not allowed"" The start type supplied does not exist.");
            new ErrorCode(List,16954, ErrorType.Monitoring, @"""Velocity overflow (overshoot in the velocity)"" The new dynamic with the parameterized jerk is so weak that a velocity overflow will occur (overshoot in the velocity). The command is therefore not supported.");
            new ErrorCode(List,16955, ErrorType.Parameter, @"""Start parameter for the axis structure is invalid"" External or internal parameters for the start structure for a positioning task are invalid. Thus, for instance, the scaling factor, the SAF cycle time or the requested velocity may be less than or equal to zero, which is not allowed.");
            new ErrorCode(List,16956, ErrorType.Parameter, @"""Override generator initialization parameter invalid"" One of the override generator (re)initialization parameters is invalid.");
            new ErrorCode(List,16957, ErrorType.Monitoring, @"""Slave axis has not set value generator"" (INTERNAL ERROR) It is found that a slave axis within a group does not have a valid slave generator (set value generator). A slave axis and a slave set value generator must always be present as a pair. This is an internal error.");
            new ErrorCode(List,16958, ErrorType.Function, @"""Table is empty"" Either the SVB table or the SAF table does not contain any entries.");
            new ErrorCode(List,16959, ErrorType.Function, @"""Table is full"" The SVB table or the SAF table has no more free lines.");
            new ErrorCode(List,16960, ErrorType.Memory, @"""No memory available"" SVB memory allocation for dynamic entry in SAF table failed.");
            new ErrorCode(List,16961, ErrorType.Function, @"""Table already contains an entry"" (INTERNAL ERROR) SAF table entry abandoned, because, incorrectly, an entry already exists.");
            new ErrorCode(List,16962, ErrorType.Function, @"""Stop is already active"" The stop instruction is not forwarded, because it has already been activated.");
            new ErrorCode(List,16963, ErrorType.Function, @"""Compensation has not been carried out over the full compensation section"" The compensations start parameters do not permit compensation over the full section to be compensated. For this reason the compensation will be carried out over a smaller section.");
            new ErrorCode(List,16964, ErrorType.Parameter, @"""Internal parameters for the compensation are invalid"" (INTERNAL ERROR) Invalid internal parameters or start parameters of the lower-level generator.");
            new ErrorCode(List,16965, ErrorType.Function, @"""Compensation active"" Start of compensation refused, because compensation is already active. It's also possible that the M/S axes are not active moved. Therefore an execution of the compensation is impossible.");
            new ErrorCode(List,16966, ErrorType.Function, @"""Compensation not active"" Stop of compensation refused, because compensation is not active.");
            new ErrorCode(List,16967, ErrorType.Function, @"""Compensation type invalid"" The type supplied for the section compensation is invalid. At the present time only compensation type 1 (trapezoidal velocity profile) is allowed.");
            new ErrorCode(List,16968, ErrorType.Function, @"""Axis address for compensation invalid"" (INTERNAL ERROR) The address of the master of slave axis on which the section compensation is to act is invalid. This is an internal error.");
            new ErrorCode(List,16969, ErrorType.Address, @"""Invalid slave address"" (INTERNAL ERROR) The slave address given for on-line coupling/decoupling is invalid.");
            new ErrorCode(List,16970, ErrorType.Function, @"""Coupling velocity invalid"" The velocity of what is to become the master axis is 0, which means that on-line coupling is not possible.");
            new ErrorCode(List,16971, ErrorType.Function, @"""Coupling velocities not constant"" The velocity of what is to become the master axis and the velocity of what is to become the slave axis are not constant, so that on-line coupling is not possible.");
            new ErrorCode(List,16972, ErrorType.Parameter, @"""Cycle time less than or equal to 0.0 is not allowed"" A value less than or equal to 0.0 for the cycle time (Slave) is not allowed, since the cycle time is by definition strictly positive, and with a cycle time of 0.0, division will generate an FPU exception.");
            new ErrorCode(List,16973, ErrorType.Function, @"""Decoupling task not allowed"" The slave axis is of such a type (e.g. a table slave) or is in such a state (master velocity 0) that on-line decoupling is not possible.");
            new ErrorCode(List,16974, ErrorType.Function, @"""Function not allowed"" The function cannot logically be executed, e.g. some commands are not possible and not allowed for slave axes.");
            new ErrorCode(List,16975, ErrorType.Parameter, @"""No valid table weighting has been set"" The weighting factor of each table is 0, so that no table can be read.");
            new ErrorCode(List,16976, ErrorType.Function, @"""Axis type, actual position type or end position type is not allowed"" The start type for a positioning task in invalid. Valid start types are ABSOLUTE (1), RELATIVE (2), CONTINUOUS POSITIVE (3), CONTINUOUS NEGATIVE (4), MODULO (5), etc. It is also possible that the types for setting a new actual position or for travel to a new end position are invalid.");
            new ErrorCode(List,16977, ErrorType.Function, @"""Function not presently supported"" An NC function has been activated that is currently not released for use, or which is not even implemented. This can be a command which is not possible or not allowed for master axes.");
            new ErrorCode(List,16978, ErrorType.Monitoring, @"""State of state machine invalid"" (INTERNAL ERROR) The state of an internal state machine is invalid. This is an internal error.");
            new ErrorCode(List,16979, ErrorType.Monitoring, @"""Reference cam became free too soon"" During the referencing process for an axis it is moved in the direction of the referencing cam, and is only stopped again when the cam signal is reached. After the axis has then also physically stopped, the referencing cam must remain occupied until the axis subsequently starts back down from the cam in the normal way.");
            new ErrorCode(List,16980, ErrorType.Monitoring, @"""Clearance monitoring between activation of the hardware latch and appearance of the sync pulse"" When the clearance monitoring is active, a check is kept on whether the number of increments between activation of the hardware latch and occurrence of the sync pulse (zero pulse) has become smaller than a pre-set value. This error is generated when that happens. (See parameters for the incremental encoder)");
            new ErrorCode(List,16981, ErrorType.Memory, @"""No memory available"" The dynamic memory allocation for the set value generator, the SVB table or the SAF table has failed.");
            new ErrorCode(List,16982, ErrorType.Monitoring, @"""The table slave axis has no active table"" Although the table slave axis has tables, none of the tables is designated as active. If this occurs during the run time the whole master/slave group is stopped by a run time error.");
            new ErrorCode(List,16983, ErrorType.Function, @"""Function not allowed"" The requested function or the requested task is not logically allowed. An example for such an error message would be ""set an actual position"" for an absolute encoder (M3000, KL5001, etc.).");
            new ErrorCode(List,16984, ErrorType.Function, @"""Stopping compensation not allowed"" It is not possible to stop the compensation, since compensation is already in the stopping phase.");
            new ErrorCode(List,16985, ErrorType.Function, @"""Slave table is being used"" The slave table cannot be activated, because it is currently being used.");
            new ErrorCode(List,16986, ErrorType.Function, @"""Master or slave axis is processing a job (e.g. positioning command) while coupling is requested"" A master/slave coupling of a certain slave type (e.g. linear coupling) cannot be executed. he master or intended slave axis is not in stand still state and is executing a job (e.g. positioning) at the same time as the coupling request received. For this couple type this is not allowed.");
            new ErrorCode(List,16987, ErrorType.Parameter, @"""Slave (start) parameter is incorrect"" One of the slave start/coupling parameters is not allowed (Coupling factor is zero, the master position scaling of an cam is zero, etc.).");
            new ErrorCode(List,16988, ErrorType.Parameter, @"""Slave type is incorrect"" The slave type does not match up to the (SVB) start type.");
            new ErrorCode(List,16989, ErrorType.Function, @"""Axis stop is already active"" The axis stop/Estop is not initiated, because the stop/estop is already active.");
            new ErrorCode(List,16990, ErrorType.Function, @"""Maximum number of tables per slavegenerator reached"" The maximum number of tables per slave generator is reached (e.g. ""MC_MultiCamIn"" is limited to 4 tables).");
            new ErrorCode(List,16991, ErrorType.Function, @"""The scaling mode is invalid"". The used scaling is invalid in this context. Either the mode is not defined or yet not implemented or however it cannot in this constellation be put into action.
For example MASTER-AUTOOFFSET cannot be used when a cam table is coupled in relative mode because this is a contradiction.
Further MASTER-AUTOOFFSET cannot be used when a cam table is coupled for the first time because a relationship to an existing reference table is missing.");
            new ErrorCode(List,16992, ErrorType.Monitoring, @"""Controller enable"" Controller enable for the axis or for a coupled slave axis is not present (see axis interface PlcToNc). This error occurs if the controller enable is withdrawn while an axis or a group of axes (also a master/slave group) is being actively positioned. The error also occurs if a PTP axis or a coupled slave axis is started without controller enable.");
            new ErrorCode(List,16993, ErrorType.Function, @"""Table not found"" No table exists with the ID prescribed or the table ID is not unique.");
            new ErrorCode(List,16994, ErrorType.Function, @"""Incorrect table type"" The table referred to in the function is of the incorrect type.");
            new ErrorCode(List,16995, ErrorType.Function, @"""Single step mode"" This error occurs if single step mode is selected for a group or axis and a new task is requested while one of the individual tasks is still being processed.");
            new ErrorCode(List,16996, ErrorType.Function, @"""Group task unknown (asynchronous table entry)"" The group has received a task whose type or sub-type is unknown. Valid tasks can be single or multi-dimensional positioning tasks (Geo 1D, Geo 3D), referencing tasks, etc.");
            new ErrorCode(List,16997, ErrorType.Function, @"""Group function unknown (synchronous function)"" The group has received a function whose type is unknown. Valid functions are ""Reset"", ""Stop"", ""New end position"", ""Start/stop section compensation"", ""Set actual position"", ""Set/reset referencing status"" etc.");
            new ErrorCode(List,16998, ErrorType.Function, @"""Group task for slave not allowed"" Group tasks are usually only possible for master axes, not for slave axes. A slave axis only moves as an indirect result of a positioning task given to its associated master axis. A slave can thus never directly be given a task.
Exception: see axis parameter ""Allow motion commands to slave axis"".");
            new ErrorCode(List,16999, ErrorType.Function, @"""Group function for slave not allowed"" Group functions are in principle only possible for master axes, not for slave axes. The only exception is represented by the ""Start/stop section compensation"" function, which is possible both for masters and for slaves. A slave cannot directly execute any other functions beyond this.");
            new ErrorCode(List,17000, ErrorType.Function, @"""GROUPERR_GROUPFUNC_NOMOTION""");
            new ErrorCode(List,17001, ErrorType.Parameter, @"""Startposition=Setpoint Position"" Invalid position parameters.");
            new ErrorCode(List,17002, ErrorType.Parameter, @"""Parameters of the delay-generator are invalid"" Invalid external/internal parameters of the delay generator (delay time, cycle time, tics).");
            new ErrorCode(List,17003, ErrorType.Parameter, @"""External parameters of the superimposed instruction are invalid"" Invalid external parameters of the superimposed functionality (acceleration, deceleration, velocity, process velocity, length).");
            new ErrorCode(List,17004, ErrorType.Parameter, @"""Invalid override type.""");
            new ErrorCode(List,17005, ErrorType.Function, @"""Activation position under/overrun"" The requested activation position is located in the past of the master (e.g. when exchanging a cam table).");
            new ErrorCode(List,17006, ErrorType.Function, @"""Activation impossible: Master is standing"" The required activation of the correction is impossible since the master axis is not moving. A synchronization is not possible, because the master axis standing and the slave axis is still not synchronous.");
            new ErrorCode(List,17007, ErrorType.Function, @"""Activation mode not possible"" The requested activation mode is not possible when the slave axis is moving. Otherwise the slave velocity would jump to zero.");
            new ErrorCode(List,17008, ErrorType.Parameter, @"""Start parameter for the compensation is invalid"" One of the dynamic parameters for the compensation is invalid (necessary condition): Acceleration (>0) Deceleration (>0) Process velocity (>0)");
            new ErrorCode(List,17009, ErrorType.Parameter, @"""Start parameter for the compensation is invalid"" Velocity camber is negative.");
            new ErrorCode(List,17010, ErrorType.Parameter, @"""Start parameter for the compensation is invalid"" The section on which the compensation is to occur is not positive.");
            new ErrorCode(List,17011, ErrorType.Monitoring, @"""Target position under/overrun"" (INTERNAL ERROR) The position (calculated from the modulo-target-position) where the axis should stand at end of oriented stop has been run over.");
            new ErrorCode(List,17012, ErrorType.Monitoring, @"""Target position will be under/overrun"" (INTERNAL ERROR) The position (calculated from the modulo-target-position) where the axis should stand at end of oriented stop is too near and will be run over.");
            new ErrorCode(List,17014, ErrorType.Monitoring, @"""GROUPERR_GUIDERSTARTDATA""");
            new ErrorCode(List,17015, ErrorType.Monitoring, @"""Dynamic parameters not permitted"" (INTERNAL ERROR) The dynamic parameters resulting from internal calculation like acceleration, deceleration and jerk are not permitted.");
            new ErrorCode(List,17017, ErrorType.Monitoring, @"""GROUPERR_GUIDEROVERRUN""");
            new ErrorCode(List,17018, ErrorType.Monitoring, @"""GROUPERR_GUIDERLOOKAHEAD""");
            new ErrorCode(List,17019, ErrorType.Monitoring, @"""GROUPERR_GUIDERLOOKAHEADEND""");
            new ErrorCode(List,17020, ErrorType.Monitoring, @"""GROUPERR_GUIDERLOOKAHEADREQU""");
            new ErrorCode(List,17021, ErrorType.Monitoring, @"""GROUPERR_GUIDERMODE""");
            new ErrorCode(List,17022, ErrorType.Monitoring, @"""A requested motion command could not be realized (BISECTION)"" A requested motion command could not be realized using the requested parameters. The command has been executed best possible and this message is therefore to be understood just as a warning. Samples:
An axis motion command is requested while the axis is in a unfavorable dynamic situation (acceleration phase), in which the covered distance is too short or the velocity is clearly too high. Another possibility is a slave axis, which is decoupled in motion in an unfavorable dynamic situation and is afterwards given a motion as in the previous case.");
            new ErrorCode(List,17023, ErrorType.Monitoring, @"""The new target position either has been overrun or will be overrun"" The new target position either has been overrun or will be overrun, since until there it is impossible to stop. An internal stop command is commended.");
            new ErrorCode(List,17024, ErrorType.Monitoring, @"""Group not ready / group not ready for new task"" (INTERNAL ERROR / INFORMATION) The group is being given a new task while it is still in the process of executing an existing task. This request is not allowed because it would interrupt the execution of the previous task. The new task could, for instance, be a positioning command, or the ""set actual position"" function. Precisely the converse relationships apply for the ""set new end position"" function. In that case, the group/axis must still be actively moving in order to be able to cause a change in the end position.");
            new ErrorCode(List,17025, ErrorType.Parameter, @"""The parameters of the oriented stop (O-Stop) are not admitted."" The modulo-target position should not be smaller than zero and not larger or equal than the encoder mod-period ( e.g. in the interval [0.0,360.0] ).
Note: In the case of error the axis is safely stopped, but is afterwards not at the requested oriented position.");
            new ErrorCode(List,17026, ErrorType.Monitoring, @"""The modulo target position of the modulo-start is invalid"" The modulo target position is outside of the valid parameter range. So the position value should not be smaller than zero and not greater or equal than the encoder modulo-period (e. g. in the interval [0.0,360.0] for the modulo start type ""SHORTEST_WAY (261)"" ).");
            new ErrorCode(List,17027, ErrorType.Parameter, @"""The online change activation mode is invalid"". The activation can be used with online scaling or with online modification of motion function. The used activation is invalid in this context. Either the mode is not defined or yet not implemented or however it cannot in this constellation be put into action (e.g. when linear tables are used with an unexpected cyclic activation mode NEXTCYCLE or NEXTCYCLEONCE).
In some case, the activation mode may be valid but the command cannot be executed due to a pending previous command.");
            new ErrorCode(List,17028, ErrorType.Parameter, @"""The parameterized jerk rate is not permitted"". The jerk rate is smaller than the minimum jerk rate. The minimum value for jerk rate is 1.0 (e.g. mm/s^3).");
            new ErrorCode(List,17029, ErrorType.Parameter, @"""The parameterized acceleration or deceleration is not permitted"". The parameterized acceleration or deceleration is lower than the permitted minimum acceleration. The value for minimum acceleration is calculated from minimum jerk rate and NC cycle time (minimum jerk rate multiplied with NC cycle time). The unit for example is mm/s^2.");
            new ErrorCode(List,17030, ErrorType.Parameter, @"""The parameterized velocity is not permitted"". The parameterized target velocity is lower than the minimum velocity (but the value zero is permitted). The value for minimum velocity is calculated from the minimum jerk rate and the NC cycle time (minimum jerk rate multiplied with the square of the NC cycle time). The unit for example is mm/s.");
            new ErrorCode(List,17031, ErrorType.Monitoring, @"""A activation cannot be executed due to a pending activation"" A activation e.g. ""CamIn"", ""CamScaling"" or ""WriteMotionFunction"" cannot be executed due to a pending activation (e.g. ""CamIn"", ""CamScaling"", ""WriteMotionFunction""). Only activation can be enabled.");
            new ErrorCode(List,17032, ErrorType.Monitoring, @"""Illegal combination of different cycle times within an axis group"" A logical axis group includes elements (axes) with different cycle times for a common setpoint generator and I/O-execution, resp. This situation can occur with Master/Slave-coupling or configuring 3D- and FIFO-groups (including path, auxiliary, and slave axes).");
            new ErrorCode(List,17033, ErrorType.Monitoring, @"""Illegal motion reversal"" Due to the actual dynamical state a motion reversal will happen. To avoid this motion reversal the axis command is not performed and the previous system state restored.");
            new ErrorCode(List,17034, ErrorType.Monitoring, @"""Illegal moment for an axis command because there is an old axis command with activation position still active"" The moment for the command is illegal because there is still an old command with activation position active (e.g. ""go to new velocity at threshold position"" or ""reach new velocity at threshold position"").");
            new ErrorCode(List,17035, ErrorType.Monitoring, @"""Error in the stop-calculation routine"" (INTERNAL ERROR) Due to an internal error in the stop-calculation routine the current commando cannot be performed. The previous system state is restored.");
            new ErrorCode(List,17036, ErrorType.Monitoring, @"""A command with activation position cannot fully be performed because the remaining path is too short""A command with activation position (threshold) like ""reach a new velocity at a position"" can be just partially executed because the path from the actual position to the activation position is too short.");
            new ErrorCode(List,17037, ErrorType.Monitoring, @"""Illegal decouple type when decoupling a slave axis"" The decouple and restart command contains an invalid decouple type.");
            new ErrorCode(List,17038, ErrorType.Monitoring, @"""Illegal target velocity when decoupling a slave axis"" The decouple and restart command contains an illegal target velocity [1 < V <Vmax].");
            new ErrorCode(List,17039, ErrorType.Monitoring, @"""The command new dynamic parameter cannot be performed since this would require a new target velocity""Das Kommando zum Aktivieren neuer Dynamikparameter wie Beschleunigung, Verzögerung und Ruck kann nicht durchgeführt werden, da dies eine neue beauftragte Fahrgeschwindigkeit erfordern würde.
This situation can occur, for example, if the axis is near the target position in an accelerated state and the dynamics parameter are chosen softer.");
            new ErrorCode(List,17040, ErrorType.Monitoring, @"""A command with activation position cannot be performed because the axis is already in the brake phase"" A command with activation position (threshold) e.g. ""reach new velocity at position"" cannot be performed because the axis is already in the brake phase and the remaining path from the actual position to the activation position is too short.");
            new ErrorCode(List,17041, ErrorType.Monitoring, @"""Decouple routine of slave axis doesn't return a valid solution"" Internal jerk scaling of decouple routine cannot evaluate a valid solution (decoupling slave axis and transform to master axis). The command is rejected because velocity can become too high, a reversal of movement can occur, or the target position can be passed.");
            new ErrorCode(List,17042, ErrorType.Monitoring, @"""Command not be executed because the command buffer is full filled"" The command is rejected because the command buffer is full filled.");
            new ErrorCode(List,17043, ErrorType.Internal, @"""Command is rejected due to an internal error in the Look Ahead"" (INTERNAL ERROR) The command is rejected due to an internal error in the ""look ahead"".");
            new ErrorCode(List,17044, ErrorType.Monitoring, @"""Command is rejected because the segment target velocity is not realized"" The command is rejected, because the new target segment velocity Vrequ is not realizable and an internal optimizing is impossible.");
            new ErrorCode(List,17045, ErrorType.Monitoring, @"""Successive commands have the same final position"" Successive commands have the same final position. So the moving distance is zero.");
            new ErrorCode(List,17046, ErrorType.Monitoring, @"""Logical positioning direction is inconsistent with the direction of the buffer command"" In the extended buffer mode, where the actual end position is replaced by the new buffer start position, the logical positioning direction is inconsistent with the direction of the buffer command (=> contradiction). A buffered command (BufferMode, BlendingLow, BlendingPrevious, BlendingNext, BlendingHigh) is rejected with error 0x4296 if the command is using the Beckhoff specific optional BlendingPosition but the blending position is located beyond the target position of the previous motion command.");
            new ErrorCode(List,17047, ErrorType.Monitoring, @"""Command is rejected because the remaining positioning length is to small"" The command is rejected because the remaining path length is too small.
E.g. when the buffer mode is used and the remaining positioning length in the actual segment is too small for getting the axis in a force free state or to reach the new target velocity at the change of segment.");
            new ErrorCode(List,17051, ErrorType.Monitoring, @"„collect error for invalid start parameters“
This error refers to a wrong parameterization of the user (collect error). E. g. dynamic parameters like Velo, Acc or Dec could be equal or less than zero.
Or following errors:
- BaseFrequence < 0.0
- StartFrequence < 1.0
- StepCount < 1, StepCount > 200
- BaseAmplitude <= 0.0
- StepDuration <= 0.0
- StopFrequence >= 1/(2*CycleTime)");
            new ErrorCode(List,17052, ErrorType.Monitoring, @"""Reference cam is not found"" During the referencing process for an axis it is moved in the direction of the referencing cam. This reference cam, however, was not found as expected (=> leads to the abortion of the referencing procedure).");
            new ErrorCode(List,17053, ErrorType.Monitoring, @"""Reference cam became not free"" During the referencing process for an axis it is moved in the direction of the referencing cam, and is only stopped again when the cam signal is reached. After the axis has also come to a physical standstill, the axis is subsequently started regularly from the cam again. In this case, the reference cam did not become free again as expected when driving down (=> leads to the abortion of the referencing procedure).");
            new ErrorCode(List,17054, ErrorType.Monitoring, @"""IO sync pulse was not found (only when using hardware latch)"" If the hardware latch is activated, a sync pulse (zero pulse) is expected to be found and a sync event triggered following the expiry of a certain time or a certain distance. If this is not the case, the reaction is an error and the abortion of the referencing procedure.");
            new ErrorCode(List,17056, ErrorType.Internal, @"""Group/axis consequential error"" Consequential error resulting from another causative error related to another axis within the group. Group/axis consequential errors can occur in relation to master/slave couplings or with multiple axis interpolating DXD groups. If, for instance, it is detected that the following error limit of a master axis has been exceeded, then this consequential error is assigned to all the other master axes and slave axes in this group.");
            new ErrorCode(List,17057, ErrorType.Parameter, @"""Velocity reduction factor for C0/C1 transition is not allowed"" A C0 transition describes two geometries which, while they are themselves continuous, no not have either continuous first or second differentials. The velocity reduction factor C0 acts on such transitions. Note: A C1 transition is characterized by the two geometries being continuous, but having only a first differential that is continuous. The velocity reduction factor C1 acts on such transitions.");

            new ErrorCode(List,17058, ErrorType.Parameter, @"""Critical angle at segment transition not allowed""");

            new ErrorCode(List,17059, ErrorType.Parameter, @"""Radius of the tolerance sphere"" is in an invalid rang");

            new ErrorCode(List,17060, ErrorType.Parameter, @"Not implemented.");
            new ErrorCode(List,17061, ErrorType.Parameter, @"""Start type""");

            new ErrorCode(List,17062, ErrorType.Parameter, @"Not implemented.");
            new ErrorCode(List,17063, ErrorType.Parameter, @"""Blending"" with given parameters not possible");
            new ErrorCode(List,17064, ErrorType.Parameter, @"Not implemented.");
            new ErrorCode(List,17065, ErrorType.Parameter, @"""Curve velocity reduction method not allowed"" (INTERNAL ERROR) The curve velocity reduction method does not exist.");
            new ErrorCode(List,17066, ErrorType.Parameter, @"""Minimum velocity not allowed"" The minimum velocity that has been entered is less than 0.0.");
            new ErrorCode(List,17067, ErrorType.Parameter, @"""Power function input not allowed"" (INTERNAL ERROR) The input parameters in the power_() function lead to an FPU exception.");
            new ErrorCode(List,17068, ErrorType.Parameter, @"""Dynamic change parameter not allowed"" A parameter that controls alterations to the dynamics is invalid. Parameter: 1. Absolute motion dynamics change: All parameters must be strictly positive. 2. Relative reduction c_f: 0.0 < c_f <= 1.0");
            new ErrorCode(List,17069, ErrorType.Memory, @"""Memory allocation error"" (INTERNAL ERROR)");
            new ErrorCode(List,17070, ErrorType.Function, @"""The calculated end position differs from the end position in the nc instruction (internal error).""");
            new ErrorCode(List,17071, ErrorType.Parameter, @"""Calculate remaining chord length""
invalid value
Value range: [0,1]");
            new ErrorCode(List,17072, ErrorType.Function, @"""Set value generator SVB active"" Starting the set value generator (SVB, SAF) has been refused, since the SVB task is already active.");
            new ErrorCode(List,17073, ErrorType.Parameter, @"""SVB parameter not allowed"" (INTERNAL ERROR) A parameter related to the internal structure of the set value generator (SVB) results in logical errors and/or to an FPU exception. Affects these parameters: Minimum velocity (>0.0), TimeMode, ModeDyn, ModeGeo, StartType, DistanceToEnd, TBallRadius.");
            new ErrorCode(List,17074, ErrorType.Parameter, @"""Velocity reduction factor not allowed"" A parameter that controls reduction of the velocity at segment transitions is invalid. Parameter: 1. Transitions with continuous first differential: VeloVertexFactorC1 2. Not once continuously differentiable transitions: VeloVertexFactorC0, CriticalVertexAngleLow, CriticalVertexAngleHigh.");
            new ErrorCode(List,17075, ErrorType.Parameter, @"""Helix is a circle"" The helix has degenerated to a circle, and should be entered as such.");
            new ErrorCode(List,17076, ErrorType.Parameter, @"""Helix is a straight line"" The helix has degenerated to a straight line, and should be entered as such.");
            new ErrorCode(List,17077, ErrorType.Parameter, @"""Guider parameter not allowed"" One of the guider's parameters leads to logical errors and/or to an FPU exception.");
            new ErrorCode(List,17078, ErrorType.Address, @"""Invalid segment address"" (INTERNAL ERROR) The geometry segment does not have a valid geometry structure address or does not have a valid dynamic structure address.");
            new ErrorCode(List,17079, ErrorType.Parameter, @"""Unparameterized generator"" (INTERNAL ERROR) The SVB generator is not yet parameterized and is therefore unable to operate.");
            new ErrorCode(List,17080, ErrorType.Address, @"""Unparameterized table"" (INTERNAL ERROR) The table has no information concerning the address of the corresponding dynamic generator.");
            new ErrorCode(List,17082, ErrorType.Internal, @"""The calculation of the arc length of the smoothed path failed (internal error).""");
            new ErrorCode(List,17083, ErrorType.Parameter, @"""The radius of the tolerance ball is too small (smaller than 0.1 mm).""");
            new ErrorCode(List,17084, ErrorType.Internal, @"Error while calculating DXD-Software-Limit switches (internal error)");
            new ErrorCode(List,17085, ErrorType.Function, @"""NC-Block violates software limit switches of the group"" At least one path axis with active software limit monitoring has violated the limit switches. Therefore the geometric entry is denied with an error.");
            new ErrorCode(List,17086, ErrorType.Parameter, @"""GROUPERR_DXD_SOFTENDCHECK""");
            new ErrorCode(List,17087, ErrorType.Parameter, @"""GROUPERR_DXD_RTTG_VELOREFERENCE""");
            new ErrorCode(List,17088, ErrorType.Internal, @"""Interpolating group contains axes of an incorrect axis type"" An interpolating 3D group may only contain continuously guided axes of axis type 1 (SERVO).");
            new ErrorCode(List,17089, ErrorType.Internal, @"""Scalar product cannot be calculated"" The length of one of the given vectors is 0.0.");
            new ErrorCode(List,17090, ErrorType.Internal, @"""Inverse cosine cannot be calculated"" The length of one of the given vectors is 0.0.");
            new ErrorCode(List,17091, ErrorType.Parameter, @"""Invalid table entry type"" The given table entry type is unknown.");
            new ErrorCode(List,17092, ErrorType.Parameter, @"""Invalid DIN66025 information type"" (INTERNAL ERROR) The given DIN66025 information type is unknown. Known types: G0, G1, G2, G3, G17, G18, G19.");
            new ErrorCode(List,17093, ErrorType.Parameter, @"""Invalid dimension"" (INTERNAL ERROR) The CNC dimension is unknown. Known dimensions: 1, 2, 3. Or: The CNC dimension is invalid for the given geometrical object. For a circle the dimension must be 2 or 3, while for a helix it must be 3.");
            new ErrorCode(List,17094, ErrorType.Parameter, @"""Geometrical object is not a straight line"" The given object, interpreted as a straight line, has a length of 0.0.");
            new ErrorCode(List,17095, ErrorType.Parameter, @"""Geometrical object is not a circle"" Interpreted as a circular arc, the given object has a length of 0.0, or an angle of 0.0 or a radius of 0.0.");
            new ErrorCode(List,17096, ErrorType.Parameter, @"""Geometrical object is not a helix"" Interpreted as a circular arc, the given object has a length of 0.0, or an angle of 0.0, or a radius of 0.0. or a height of 0.0.");
            new ErrorCode(List,17097, ErrorType.Parameter, @"""Set velocity less than or equal to 0.0 is invalid"" A value less than or equal to 0.0 for the set velocity (CNC) is not allowed, since the set velocity is positive by definition, and a set velocity of 0.0 cannot generate any motion.");
            new ErrorCode(List,17098, ErrorType.Address, @"""Address for look-ahead invalid"" (INTERNAL ERROR) The address supplied for the look-ahead is invalid.");
            new ErrorCode(List,17099, ErrorType.Function, @"""Set value generator SAF active"" Starting the set value generator (SAF) has been refused, since the SAF task is already active.");
            new ErrorCode(List,17100, ErrorType.Function, @"""CNC set value generation not active"" Stop or change of override refused, because the set value generation is not active.");
            new ErrorCode(List,17101, ErrorType.Function, @"""CNC set value generation in the stop phase"" Stop or change of override refused, because the set value generation is in the stop phase.");
            new ErrorCode(List,17102, ErrorType.Parameter, @"""Override not allowed"" An override of less than 0.0 % or more than 100.0 % is invalid.");
            new ErrorCode(List,17103, ErrorType.Address, @"""Invalid table address"" (INTERNAL ERROR) The table address given for the initialization of the set value generator is invalid, or no valid logger connection (report file) is present.");
            new ErrorCode(List,17104, ErrorType.Parameter, @"""Invalid table entry type"" The given table entry type is unknown.");
            new ErrorCode(List,17105, ErrorType.Memory, @"""Memory allocation failed"" Memory allocation for the table has failed.");
            new ErrorCode(List,17106, ErrorType.Memory, @"""Memory allocation failed"" Memory allocation for the filter has failed.");
            new ErrorCode(List,17107, ErrorType.Parameter, @"""Invalid parameter"" Filter parameter is not allowed.");
            new ErrorCode(List,17108, ErrorType.Function, @"""Delete Distance To Go failed"" Delete Distance to go (only interpolation) failed. This error occurred, if e.g. the command 'DelDTG' was not programmed in the actual movement of the nc program.");
            new ErrorCode(List,17109, ErrorType.Internal, @"""The setpoint generator of the flying saw generates incompatible values (internal error)""");
            new ErrorCode(List,17110, ErrorType.Function, @"""Axis will be stopped since otherwise it will overrun its target position (old PTP setpoint generator)"" If, for example, in case of a slave to master transformation for the new master a target position is commanded that will be overrun because of the actual dynamics the axis will be stopped internally to guarantee that the target position will not be overrun.");
            new ErrorCode(List,17111, ErrorType.Function, @"""Internal error in the transformation from slave to master.""");
            new ErrorCode(List,17112, ErrorType.Function, @"""Wrong direction in the transformation of slave to master.""");
            new ErrorCode(List,17114, ErrorType.Parameter, @"""Parameter of Motion Function (MF) table incorrect"" The parameter of the Motion Function (MF) are invalid. This may refer to the first time created data set or to online changed data.");
            new ErrorCode(List,17115, ErrorType.Parameter, @"""Parameter of Motion Function (MF) table incorrect"" The parameter of the Motion Function (MF) are invalid. This may refer to the first time created data set or to online changed data.
The error cause can be, that an active MF point (no IGNORE point) points at a passive MF point (IGNORE point).");
            new ErrorCode(List,17116, ErrorType.Monitoring, @"""Internal error by using Motion Function (MF)"" An internal error occurs by using the Function (MF). This error cannot be solved by the user. Please ask the TwinCAT Support.");
            new ErrorCode(List,17117, ErrorType.Function, @"""Axis coupling with synchronization generator declined because of incorrect axis dynamic values"" The axis coupling with the synchronization generator has been declined, because one of the slave dynamic parameter (machine data) is incorrect. Either the maximum velocity, the acceleration, the deceleration or the jerk is smaller or equal to zero, or the expected synchronous velocity of the slave axis is higher as the maximum allowed slave velocity.");
            new ErrorCode(List,17118, ErrorType.Function, @"""Coupling conditions of synchronization generator incorrect"" During positive motion of the master axis it has to be considered, that the master synchronous position is larger than the master coupling position (""to be in the future""). During negative motion of the master axis it has to be considered that the master synchronous position is smaller than the master coupling position.");
            new ErrorCode(List,17119, ErrorType.Monitoring, @"""Moving profile of synchronization generator declines dynamic limit of slave axis or required characteristic of profile"" One of the parameterized checks has recognized an overstepping of the dynamic limits (max. velocity, max. acceleration, max. deceleration or max. jerk) of the slave axis, or an profile characteristic (e.g. overshoot or undershoot in the position or velocity) is incorrect.
See also further messages in the windows event log and in the message window of the System Manager.");
            new ErrorCode(List,17120, ErrorType.Parameter, @"""Invalid parameter"" The encoder generator parameter is not allowed.");
            new ErrorCode(List,17121, ErrorType.Parameter, @"""Invalid parameter"" The external (Fifo) generator parameter is not allowed.");
            new ErrorCode(List,17122, ErrorType.Function, @"""External generator is active"" The external generator cannot be started, as it is already active.");
            new ErrorCode(List,17123, ErrorType.Function, @"""External generator is not active"" The external generator cannot be stopped, as it is not active.");
            new ErrorCode(List,17124, ErrorType.Function, @"""NC-Block with auxiliary axis violates software limit switches of the group"" At least one auxiliary axis with active software limit monitoring has violated the limit switches. Therefore the geometric entry is denied with an error.");
            new ErrorCode(List,17125, ErrorType.Function, @"""NC-Block type Bezier spline curve contains a cusp (singularity)"" The Bezier spline curve contain a cusp, i.e. at a certain interior point both the curvature and the modulus of the velocity tend to 0 such that the radius of curvature is infinite.
Note: Split the Bezier curve at that point into two Bezier spline curves according to the de ""Casteljau algorithm"". This preserves the geometry and eliminates the interior singularity.");
            new ErrorCode(List,17127, ErrorType.Parameter, @"""Value for dead time compensation not allowed"" The value for the dead time compensation in seconds for a slave coupling to an encoder axis (virtual axis) is not allowed.");

            new ErrorCode(List,17128, ErrorType.Parameter, @"""GROUPERR_RANGE_NOMOTIONWINDOW""");

            new ErrorCode(List,17129, ErrorType.Parameter, @"""GROUPERR_RANGE_NOMOTIONFILTERTIME""");

            new ErrorCode(List,17130, ErrorType.Parameter, @"""GROUPERR_RANGE_TIMEUNITFIFO""");

            new ErrorCode(List,17131, ErrorType.Parameter, @"""GROUPERR_RANGE_OVERRIDETYPE""");

            new ErrorCode(List,17132, ErrorType.Parameter, @"""GROUPERR_RANGE_OVERRIDECHANGETIME""");

            new ErrorCode(List,17133, ErrorType.Parameter, @"""GROUPERR_FIFO_INVALIDDIMENSION""
Note: Since TC 2.11 Build 1547 the FIFO-dimension (number of axes) has been increased from 8 to 16.");

            new ErrorCode(List,17134, ErrorType.Address, @"""GROUPERR_ADDR_FIFOTABLE""");
            new ErrorCode(List,17135, ErrorType.Monitoring, @"""Axis is locked for motion commands because a stop command is still active"" The axis/group is locked for motion commands because a stop command is still active. The axis can be released by calling MC_Stop with Execute=FALSE or by using MC_Reset (TcMC2.Lib).");
            new ErrorCode(List,17136, ErrorType.Parameter, @"""Invalid number of auxiliary axes"" The local number of auxiliary axes does not tally with the global number of auxiliary axes.");
            new ErrorCode(List,17137, ErrorType.Parameter, @"""Invalid reduction parameter for auxiliary axes"" The velocity reduction parameters for the auxiliary axes are inconsistent.");
            new ErrorCode(List,17138, ErrorType.Parameter, @"""Invalid dynamic parameter for auxiliary axes"" The dynamic parameters for the auxiliary axes are inconsistent.");
            new ErrorCode(List,17139, ErrorType.Parameter, @"""Invalid coupling parameter for auxiliary axes"" The coupling parameters for the auxiliary axes are inconsistent.");
            new ErrorCode(List,17140, ErrorType.Parameter, @"""Invalid auxiliary axis entry"" The auxiliary axis entry is empty (no axis motion).");
            new ErrorCode(List,17142, ErrorType.Parameter, @"""Invalid parameter"" The limit for velocity reduction of the auxiliary axes is invalid. It has to be in the interval 0..1.0");
            new ErrorCode(List,17144, ErrorType.Parameter, @"""Block search - segment not found"" The segment specified as a parameter could not be found by the end of the NC program.
Possible cause:
▪
nBlockId is not specified in the mode described by eBlockSearchMode
 ");
            new ErrorCode(List,17145, ErrorType.Parameter, @"""Blocksearch – invalid remaining segment length"" The remaining travel in the parameter fLength is incorrectly parameterized");
            new ErrorCode(List,17147, ErrorType.Monitoring, @"""INTERNAL ERROR"" (GROUPERR_SLAVE_INTERNAL)");
            new ErrorCode(List,17151, ErrorType.Monitoring, @"„GROUPERR_WATCHDOG“ (Customer specific error code)");

            #endregion

            #region Axis Errors


            new ErrorCode(List,17152, ErrorType.Parameter, @"""Axis ID not allowed"" The value for the axis ID is not allowed, e.g. because it has already been assigned, is less than or equal to zero, is greater than 255, or does not exist in the current configuration.");

            new ErrorCode(List,17153, ErrorType.Parameter, @"""Axis type not allowed"" The value for the axis type is unacceptable because it is not defined. Type 1: Servo Type 2: Fast/creep Type 3: Stepper motor");

            new ErrorCode(List,17158, ErrorType.Parameter, @"""Slow manual velocity not allowed"" The value for the slow manual velocity is not allowed.");

            new ErrorCode(List,17159, ErrorType.Parameter, @"""Fast manual velocity not allowed"" The value for the fast manual velocity is not allowed.");

            new ErrorCode(List,17160, ErrorType.Parameter, @"""High speed not allowed"" The value for the high speed is not allowed.");

            new ErrorCode(List,17161, ErrorType.Parameter, @"""Acceleration not allowed"" The value for the axis acceleration is not allowed.");

            new ErrorCode(List,17162, ErrorType.Parameter, @"""Deceleration not allowed"" The value for the axis deceleration is not allowed.");

            new ErrorCode(List,17163, ErrorType.Parameter, @"""Jerk not allowed"" The value for the axis jerk is not allowed.");

            new ErrorCode(List,17164, ErrorType.Parameter, @"""Delay time between position and velocity is not allowed"" The value for the delay time between position and velocity (""idle time compensation"") is not allowed.");

            new ErrorCode(List,17165, ErrorType.Parameter, @"""Override-Type not allowed"" The value for the velocity override type is not allowed. Type 1: With respect to the internal reduced velocity (default value) Type 2: With respect to the original external start velocity");

            new ErrorCode(List,17166, ErrorType.Parameter, @"""NCI: Velo-Jump-Factor not allowed""
The value for the velo-jump-factor (""VeloJumpFactor"") is not allowed. This parameter only works for TwinCAT NCI.");

            new ErrorCode(List,17167, ErrorType.Parameter, @"""NCI: Radius of tolerance sphere for the auxiliary axes is invalid""
It was tried to enter an invalid value for the size of the tolerance sphere. This sphere affects only auxiliary axes!");

            new ErrorCode(List,17168, ErrorType.Parameter, @"""NCI: Value for maximum deviation for the auxiliary axes is invalid""
It was tried to enter an invalid value for the maximum allowed deviation. This parameter affects only auxiliary axes!");

            new ErrorCode(List,17170, ErrorType.Parameter, @"""Referencing velocity in direction of cam not allowed"" The value for the referencing velocity in the direction of the referencing cam is not allowed.");

            new ErrorCode(List,17171, ErrorType.Parameter, @"""Referencing velocity in sync direction not allowed"" The value for the referencing velocity in the direction of the sync pulse (zero track) is not allowed.");

            new ErrorCode(List,17172, ErrorType.Parameter, @"""Pulse width in positive direction not allowed"" The value for the pulse width in the positive direction is not allowed (pulsed operation). The use of the pulse width for positioning is chosen implicitly through the axis start type. Pulsed operation corresponds to positioning with a relative displacement that corresponds precisely to the pulse width.");

            new ErrorCode(List,17173, ErrorType.Parameter, @"""Pulse width in negative direction not allowed"" The value for the pulse width in the negative direction is not allowed (pulsed operation). The use of the pulse width for positioning is chosen implicitly through the axis start type. Pulsed operation corresponds to positioning with a relative displacement that corresponds precisely to the pulse width.");

            new ErrorCode(List,17174, ErrorType.Parameter, @"""Pulse time in positive direction not allowed"" The value for the pulse width in the positive direction is not allowed (pulsed operation).");

            new ErrorCode(List,17175, ErrorType.Parameter, @"""Pulse time in negative direction not allowed"" The value for the pulse width in the negative direction is not allowed (pulsed operation).");

            new ErrorCode(List,17176, ErrorType.Parameter, @"""Creep distance in positive direction not allowed"" The value for the creep distance in the positive direction is not allowed.");

            new ErrorCode(List,17177, ErrorType.Parameter, @"""Creep distance in negative direction not allowed"" The value for the creep distance in the negative direction is not allowed.");

            new ErrorCode(List,17178, ErrorType.Parameter, @"""Braking distance in positive direction not allowed"" The value for the braking distance in the positive direction is not allowed.");

            new ErrorCode(List,17179, ErrorType.Parameter, @"""Braking distance in negative direction not allowed"" The value for the braking distance in the negative direction is not allowed.");

            new ErrorCode(List,17180, ErrorType.Parameter, @"""Braking time in positive direction not allowed"" The value for the braking time in the positive direction is not allowed.");

            new ErrorCode(List,17181, ErrorType.Parameter, @"""Braking time in negative direction not allowed"" The value for the braking time in the negative direction is not allowed.");

            new ErrorCode(List,17182, ErrorType.Parameter, @"""Switching time from high to low speed not allowed"" The value for the time to switch from high to low speed is not allowed.");

            new ErrorCode(List,17183, ErrorType.Parameter, @"""Creep distance for stop not allowed"" The value for the creep distance for an explicit stop is not allowed.");

            new ErrorCode(List,17184, ErrorType.Parameter, @"""Motion monitoring not allowed"" The value for the activation of the motion monitoring is not allowed.");

            new ErrorCode(List,17185, ErrorType.Parameter, @"""Position window monitoring not allowed"" The value for the activation of the position window monitoring is not allowed.");

            new ErrorCode(List,17186, ErrorType.Parameter, @"""Target window monitoring not allowed"" The value for the activation of target window monitoring is not allowed.");

            new ErrorCode(List,17187, ErrorType.Parameter, @"""Loop not allowed"" The value for the activation of loop movement is not allowed.");

            new ErrorCode(List,17188, ErrorType.Parameter, @"""Motion monitoring time not allowed"" The value for the motion monitoring time is not allowed.");

            new ErrorCode(List,17189, ErrorType.Parameter, @"""Target window range not allowed"" The value for the target window is not allowed.");

            new ErrorCode(List,17190, ErrorType.Parameter, @"""Position window range not allowed"" The value for the position window is not allowed.");

            new ErrorCode(List,17191, ErrorType.Parameter, @"""Position window monitoring time not allowed"" The value for the position window monitoring time is not allowed.");

            new ErrorCode(List,17192, ErrorType.Parameter, @"""Loop movement not allowed"" The value for the loop movement is not allowed.");

            new ErrorCode(List,17193, ErrorType.Parameter, @"""Axis cycle time not allowed"" The value for the axis cycle time is not allowed.");

            new ErrorCode(List,17194, ErrorType.Parameter, @"""Stepper motor operating mode not allowed"" The value for the stepper motor operating mode is not allowed.");

            new ErrorCode(List,17195, ErrorType.Parameter, @"""Displacement per stepper motor step not allowed"" The value for the displacement associated with one step of the stepper motor is not allowed (step scaling).");

            new ErrorCode(List,17196, ErrorType.Parameter, @"""Minimum speed for stepper motor set value profile not allowed"" The value for the minimum speed of the stepper motor speed profile is not allowed.");

            new ErrorCode(List,17197, ErrorType.Parameter, @"""Stepper motor stages for one speed stage not allowed"" The value for the number of steps for each speed stage in the set value generation is not allowed.");

            new ErrorCode(List,17198, ErrorType.Parameter, @"""DWORD for the interpretation of the axis units not allowed"" The value that contains the flags for the interpretation of the position and velocity units is not allowed.");

            new ErrorCode(List,17199, ErrorType.Parameter, @"""Maximum velocity not allowed"" The value for the maximum permitted velocity is not allowed.");

            new ErrorCode(List,17200, ErrorType.Parameter, @"""Motion monitoring window not allowed"" The value for the motion monitoring window is not allowed.");

            new ErrorCode(List,17201, ErrorType.Parameter, @"""PEH time monitoring not allowed"" The value for the activation of the PEH time monitoring is not allowed (PEH: positioning end and halt).");

            new ErrorCode(List,17202, ErrorType.Parameter, @"""PEH monitoring time not allowed"" The value for the PEH monitoring time (timeout) is not allowed (PEH: positioning end and halt). default value: 5s");

            new ErrorCode(List,17203, ErrorType.Parameter, @"""AXISERR_RANGE_DELAYBREAKRELEASE""");
            new ErrorCode(List,17204, ErrorType.Parameter, @"""AXISERR_RANGE_DATAPERSISTENCE""");
            new ErrorCode(List,17210, ErrorType.Parameter, @"""AXISERR_RANGE_POSDIFF_FADING_ACCELERATION""");
            new ErrorCode(List,17211, ErrorType.Parameter, @"""Fast Axis Stop Signal Type not allowed"" The value for the Signal Type of the 'Fast Axis Stop' is not allowed [0...5].");
            new ErrorCode(List,17216, ErrorType.Initialization, @"""Axis initialization"" Axis has not been initialized. Although the axis has been created, the rest of the initialization has not been performed (1. Initialization of axis I/O, 2. Initialization of axis, 3. Reset axis).");
            new ErrorCode(List,17217, ErrorType.Address, @"""Group address"" Axis does not have a group, or the group address has not been initialized (group contains the set value generation).");
            new ErrorCode(List,17218, ErrorType.Address, @"""Encoder address"" The axis does not have an encoder, or the encoder address has not been initialized.");
            new ErrorCode(List,17219, ErrorType.Address, @"""Controller address"" The axis does not have a controller, or the controller address has not been initialized.");
            new ErrorCode(List,17220, ErrorType.Address, @"""Drive address"" The axis does not have a drive, or the drive address has not been initialized.");
            new ErrorCode(List,17221, ErrorType.Address, @"""Axis interface PLC to NC address"" Axis does not have an axis interface from the PLC to the NC, or the axis interface address has not been initialized.");
            new ErrorCode(List,17222, ErrorType.Address, @"""Axis interface NC to PLC address"" Axis does not have an axis interface from the NC to the PLC, or the axis interface address has not been initialized.");
            new ErrorCode(List,17223, ErrorType.Address, @"""Size of axis interface NC to PLC is not allowed"" (INTERNAL ERROR) The size of the axis interface from NC to PLC is not allowed.");
            new ErrorCode(List,17224, ErrorType.Address, @"""Size of axis interface PLC to NC is not allowed"" (INTERNAL ERROR) The size of the axis interface from PLC to NC is not allowed.");

            new ErrorCode(List,17238, ErrorType.Monitoring, @"""Controller enable"" Controller enable for the axis is not present (see axis interface SPS®NC). This enable is required, for instance, for an axis positioning task.");
            new ErrorCode(List,17239, ErrorType.Monitoring, @"""Feed enable minus"" Feed enable for movement in the negative direction is not present (see axis interface SPS®NC). This enable is required, for instance, for an axis positioning task in the negative direction.");
            new ErrorCode(List,17240, ErrorType.Monitoring, @"""Feed enable plus"" Feed enable for movement in the positive direction is not present (see axis interface SPS®NC). This enable is required, for instance, for an axis positioning task in the positive direction.");
            new ErrorCode(List,17241, ErrorType.Monitoring, @"""Set velocity not allowed"" The set velocity requested for a positioning task is not allowed. This can happen if the velocity is less than or equal to zero, larger than the maximum permitted axis velocity, or, in the case of servo-drives, is larger than the reference velocity of the axis (see axis and drive parameters).");
            new ErrorCode(List,17242, ErrorType.Monitoring, @"""Movement smaller than one encoder increment"" (INTERNAL ERROR) The movement required of an axis is, in relation to a positioning task, smaller than one encoder increment (see scaling factor). This information is, however, handled internally in such a way that the positioning is considered to have been completed without an error message being returned.");
            new ErrorCode(List,17243, ErrorType.Monitoring, @"""Set acceleration monitoring"" (INTERNAL ERROR) The set acceleration has exceeded the maximum permitted acceleration or deceleration parameters of the axis.");
            new ErrorCode(List,17244, ErrorType.Monitoring, @"""PEH time monitoring"" The PEH time monitoring has detected that, after the PEH monitoring time that follows a positioning has elapsed, the target position window has not been reached. The following points must be checked: Is the PEH monitoring time, in the sense of timeout monitoring, set to a sufficiently large value (e.g. 1-5 s)? The PEH monitoring time must be chosen to be significantly larger than the target position monitoring time. Have the criteria for the target position monitoring (range window and time) been set too strictly? Note: The PEH time monitoring only functions when target position monitoring is active!");
            new ErrorCode(List,17245, ErrorType.Monitoring, @"""Encoder existence monitoring / movement monitoring"" During the active positioning the actual encoder value has changed continuously for a default check time from NC cycle to NC cycle less than the default minimum movement limit. => Check, whether axis is mechanically blocked, or the encoder system failed, etc... Note: The check is not performed while the axis is logically standing (position control), but only at active positioning (it would make no sense if there is a mechanical holding brake at the standstill)!");
            new ErrorCode(List,17246, ErrorType.Monitoring, @"""Looping distance less than breaking distance"" The absolute value of the looping distance is less or equal than the positive or negative breaking distance. This is not allowed.");
            new ErrorCode(List,17249, ErrorType.Monitoring, @"""Time range exceeded (future)"" The calculated position lies too far in the future (e.g. when converting a position value in a DC time stamp).");
            new ErrorCode(List,17250, ErrorType.Monitoring, @"""Time range exceeded (past)"" The calculated position lies too far in the past (e.g. when converting a position value in a DC time stamp).");
            new ErrorCode(List,17251, ErrorType.Monitoring, @"""Position cannot be determined"" The requested position cannot be determined. Case 1: It was not passed through in the past. Case 2: It cannot be reached in future. A reason can be a zero velocity value or an acceleration that causes a turn back.");
            new ErrorCode(List,17252, ErrorType.Monitoring, @"""Position indeterminable (conflicting direction of travel)"" The direction of travel expected by the caller of the function deviates from the actual direction of travel (conflict between PLC and NC view, for example when converting a position to a DC time).");
            new ErrorCode(List,17312, ErrorType.Internal, @"""Axis consequential error"" Consequential error resulting from another causative error related to another axis. Axis consequential errors can occur in relation to master/slave couplings or with multiple axis interpolating DXD groups.");


            #endregion

            #region Encoder Errors

            new ErrorCode(List,17408, ErrorType.Parameter, @"""Encoder ID not allowed"" The value for the encoder ID is not allowed, e.g. because it has already been assigned, is less than or equal to zero, or is bigger than 255.");

            new ErrorCode(List,17409, ErrorType.Parameter, @"""Encoder type not allowed"" The value for the encoder type is unacceptable because it is not defined. Type 1: Simulation (incremental) Type 2: M3000 (24 bit absolute) Type 3: M31x0 (24 bit incremental) Type 4: KL5101 (16 bit incremental) Type 5: KL5001 (24 bit absolute SSI) Type 6: KL5051 (16 bit BISSI)");

            new ErrorCode(List,17410, ErrorType.Parameter, @"""Encoder mode"" The value for the encoder (operating) mode is not allowed. Mode 1: Determination of the actual position Mode 2: Determination of the actual position and the actual velocity (filter)");

            new ErrorCode(List,17411, ErrorType.Parameter, @"""Encoder counting direction inverted?"" The flag for the encoder counting direction is not allowed. Flag 0: Positive encoder counting direction Flag 1: Negative encoder counting direction");

            new ErrorCode(List,17412, ErrorType.Initialization, @"""Referencing status"" The flag for the referencing status is not allowed. Flag 0: Axis has not been referenced Flag 1: Axis has been referenced");

            new ErrorCode(List,17413, ErrorType.Parameter, @"""Encoder increments for each physical encoder rotation"" The value for the number of encoder increments for each physical rotation of the encoder is not allowed. This value is used by the software for the calculation of encoder overruns and underruns.");

            new ErrorCode(List,17414, ErrorType.Parameter, @"""Scaling factor"" The value for the scaling factor is not allowed. This scaling factor provides the weighting for the conversion of an encoder increment (INC) to a physical unit such as millimeters or degrees.");

            new ErrorCode(List,17415, ErrorType.Parameter, @"""Position offset (zero point offset)"" The value for the position offset of the encoder is not allowed. This value is added to the calculated encoder position, and is interpreted in the physical units of the encoder.");

            new ErrorCode(List,17416, ErrorType.Parameter, @"""Modulo factor"" The value for the encoder's modulo factor is not allowed.");

            new ErrorCode(List,17417, ErrorType.Parameter, @"""Position filter time"" The value for the actual position filter time is not allowed (P-T1 filter).");

            new ErrorCode(List,17418, ErrorType.Parameter, @"""Velocity filter time"" The value for the actual velocity filter time is not allowed (P-T1 filter).");

            new ErrorCode(List,17419, ErrorType.Parameter, @"""Acceleration filter time"" The value for the actual acceleration filter time is not allowed (P-T1 filter).");

            new ErrorCode(List,17420, ErrorType.Initialization, @"""Cycle time not allowed"" (INTERNAL ERROR) The value of the SAF cycle time for the calculation of actual values is not allowed (e.g. is less than or equal to zero).");
            new ErrorCode(List,17421, ErrorType.Initialization, @""""" ENCERR_RANGE_UNITFLAGS");
            new ErrorCode(List,17422, ErrorType.Parameter, @"""Actual position correction / measurement system error correction"" The value for the activation of the actual position correction (""measuring system error correction"") is not allowed.");

            new ErrorCode(List,17423, ErrorType.Parameter, @"""Filter time actual position correction"" The value for the actual position correction filter time is not allowed (P-T1 filter).");

            new ErrorCode(List,17424, ErrorType.Parameter, @"""Search direction for referencing cam inverted"" The value of the search direction of the referencing cam in a referencing procedure is not allowed. Value 0: Positive direction Value 1: Negative direction");

            new ErrorCode(List,17425, ErrorType.Parameter, @"""Search direction for sync pulse (zero pulse) inverted"" The value of the search direction of the sync pulse (zero pulse) in a referencing procedure is not allowed. Value 0: Positive direction Value 1: Negative direction");

            new ErrorCode(List,17426, ErrorType.Parameter, @"""Reference position"" The value of the reference position in a referencing procedure is not allowed.");

            new ErrorCode(List,17427, ErrorType.Parameter, @"""Clearance monitoring between activation of the hardware latch and appearance of the sync pulse"" (NOT IMPLEMENTED) The flag for the clearance monitoring between activation of the hardware latch and occurrence of the sync/zero pulse (""latch valid"") is not allowed. Value 0: Passive Value 1: Active");

            new ErrorCode(List,17428, ErrorType.Parameter, @"""Minimum clearance between activation of the hardware latch and appearance of the sync pulse"" (NOT IMPLEMENTED) The value for the minimum clearance in increments between activation of the hardware latch and occurrence of the sync/zero pulse (""latch valid"") during a referencing procedure is not allowed.");

            new ErrorCode(List,17429, ErrorType.Parameter, @"""External sync pulse"" (NOT IMPLEMENTED) The value of the activation or deactivation of the external sync pulse in a referencing procedure is not allowed. Value 0: Passive Value 1: Active");

            new ErrorCode(List,17430, ErrorType.Parameter, @"""Scaling of the noise rate is not allowed"" The value of the scaling (weighting) of the synthetic noise rate is not allowed. This parameter exists only in the simulation encoder and serves to produce a realistic simulation.");

            new ErrorCode(List,17431, ErrorType.Parameter, @"„Tolerance window for modulo-start“ The value for the tolerance window for the modulo-axis-start is invalid. The value must be greater or equal than zero and smaller than the half encoder modulo-period (e. g. in the interval [0.0,180.0) ).");

            new ErrorCode(List,17432, ErrorType.Parameter, @"„Encoder reference mode“ The value for the encoder reference mode is not allowed, resp. is not supported for this encoder type.");

            new ErrorCode(List,17433, ErrorType.Parameter, @"„Encoder evaluation direction“ The value for the encoder evaluation direction (log. counter direction) is not allowed.");

            new ErrorCode(List,17434, ErrorType.Parameter, @"„Encoder reference system“ The value for the encoder reference system is invalid (0: incremental, 1: absolute, 2: absolute+modulo).");

            new ErrorCode(List,17435, ErrorType.Parameter, @"„Encoder position initialization mode“ When starting the TC system the value for the encoder position initialization mode is invalid.");

            new ErrorCode(List,17436, ErrorType.Parameter, @"„Encoder sign interpretation (UNSIGNED- / SIGNED- data type)“ The value for the encoder sign interpretation (data type) for the encoder the actual increment calculation (0: Default/not defined, 1: UNSIGNED, 2:/ SIGNED) is invalid.");

            new ErrorCode(List,17440, ErrorType.Parameter, @"""Software end location monitoring minimum not allowed"" The value for the activation of the software location monitoring minimum is not allowed.");

            new ErrorCode(List,17441, ErrorType.Parameter, @"""Software end location monitoring maximum not allowed"" The value for the activation of the software location monitoring maximum is not allowed.");

            new ErrorCode(List,17442, ErrorType.Function, @"""Actual value setting is outside the value range"" The ""set actual value"" function cannot be carried out, because the new actual position is outside the expected range of values.");

            new ErrorCode(List,17443, ErrorType.Parameter, @"""Software end location minimum not allowed"" The value for the software end location minimum is not allowed.");

            new ErrorCode(List,17444, ErrorType.Parameter, @"""Software end location maximum not allowed"" The value for the software end location maximum is not allowed.");

            new ErrorCode(List,17445, ErrorType.Parameter, @"„Filter mask for the raw data of the encoder is invalid“ The value for the filter mask of the encoder raw data in increments is invalid.");

            new ErrorCode(List,17446, ErrorType.Parameter, @"„Reference mask for the raw data of the encoder is invalid“ The value for the reference mask (increments per encoder turn, absolute resolution) for the raw data of the encoder is invalid. E.g. this value is used for axis reference sequence (calibration) with the reference mode ""Software Sync"".");

            new ErrorCode(List,17456, ErrorType.Function, @"""Hardware latch activation (encoder)"" Activation of the encoder hardware latch was implicitly initiated by the referencing procedure. If this function has already been activated but a latch value has not yet become valid (""latch valid""), another call to the function is refused with this error.");
            new ErrorCode(List,17457, ErrorType.Function, @"""External hardware latch activation (encoder)"" The activation of the external hardware latch (only available on the KL5101) is initiated explicitly by an ADS command (called from the PLC program of the Visual Basic interface). If this function has already been activated, but the latch value has not yet been made valid by an external signal (""external latch valid""), another call to the function is refused with this error.");
            new ErrorCode(List,17458, ErrorType.Function, @"""External hardware latch activation (encoder)"" If a referencing procedure has previously been initiated and the hardware still signals a valid latch value (""latch valid""), this function must not be called. In practice, however, this error can almost never occur.");
            new ErrorCode(List,17459, ErrorType.Function, @"""External hardware latch activation (encoder)"" If this function has already been initiated and the hardware is still signaling that the external latch value is still valid (""extern latch valid""), a further activation should not be carried out and the commando will be declined with an error (the internal handshake communication between NC and IO device is still active). In that case the validity of the external hardware latch would immediately be signaled, although the old latch value would still be present.");
            new ErrorCode(List,17460, ErrorType.Monitoring, @"""Encoder function not supported"" An encoder function has been activated that is currently not released for use, or which is not even implemented.");
            new ErrorCode(List,17461, ErrorType.Monitoring, @"„Encoder function is already active“ An encoder function can not been activated because this functionality is already active.");
            new ErrorCode(List,17472, ErrorType.Initialization, @"""Encoder initialization"" Encoder has not been initialized. Although the axis has been created, the rest of the initialization has not been performed (1. Initialization of axis I/O, 2. Initialization of axis, 3. Reset axis).");
            new ErrorCode(List,17473, ErrorType.Address, @"""Axis address"" The encoder does not have an axis, or the axis address has not been initialized.");
            new ErrorCode(List,17474, ErrorType.Address, @"""I/O input structure address"" The drive does not have a valid I/O input address in the process image.");
            new ErrorCode(List,17475, ErrorType.Address, @"""I/O output structure address"" The encoder does not have a valid I/O output address in the process image.");
            new ErrorCode(List,17488, ErrorType.Monitoring, @"""Encoder counter underflow monitoring"" The encoder's incremental counter has underflowed.");
            new ErrorCode(List,17489, ErrorType.Monitoring, @"""Encoder counter overflow monitoring"" The encoder's incremental counter has overflowed.");
            new ErrorCode(List,17504, ErrorType.Monitoring, @"""Software end location minimum (axis start)"" With active monitoring of the software end location for a minimum, a start has been made from a position that lies below the software end location minimum.");
            new ErrorCode(List,17505, ErrorType.Monitoring, @"""Software end location maximum (axis start)"" With active monitoring of the software end location for a maximum, a start has been made from a position that lies above the software end location maximum.");
            new ErrorCode(List,17506, ErrorType.Monitoring, @"""Software end location minimum (positioning process)"" With active monitoring of the software end location for a minimum, the actual position has fallen below the software end location minimum. In the case of servo axes (continuously driven axes) this limit is expanded by the magnitude of the parameterized following error window (position).");
            new ErrorCode(List,17507, ErrorType.Monitoring, @"""Software end location maximum (positioning process)"" With active monitoring of the software end location for a maximum, the actual position has exceeded the software end location maximum. In the case of servo axes (continuously driven axes) this limit is expanded by the magnitude of the parameterized following error window (position).");
            new ErrorCode(List,17508, ErrorType.Monitoring, @"„Encoder hardware error“ The drive resp. the encoder system reports a hardware error of the encoder. An optimal error code is displayed in the message of the event log.");
            new ErrorCode(List,17509, ErrorType.Monitoring, @"„Position initialization error at system start“ At the first initialization of the set position was this for all initialization trials (without over-/under-flow, with underflow and overflow ) out of the final position minimum and maximum.");
            new ErrorCode(List,17510, ErrorType.Monitoring, @"Invalid IO data for more than n subsequent NC cycles (encoder)
The axis (encoder) has detected for more than n subsequent NC cycles (NC SAF task) invalid encoder IO data (e.g. n=3). Typically, regarding an EtherCAT member it is about a Working Counter Error (WcState) what displays that data transfer between IO device and controller is disturbed.
If this error is set for a longer period of time continuously, this situation can lead to losing the axis reference (the “homed” flag will be reset and the encoder will get the state “unreferenced”).
Possible reasons for this error: An EtherCAT slave may have left its OP state or there is a too high real time usage or a too high real time jitter.");
            new ErrorCode(List,17511, ErrorType.Monitoring, @"Invalid Actual Position(Encoder)
The IO device delivers an invalid actual position(for CANopen / CoE look at bit 13 of encoder state “TxPDO data invalid” or “invalid actual position value”).");
            new ErrorCode(List,17512, ErrorType.Monitoring, @"Invalid IO Input Data (Error Type 1)
The monitoring of the “cyclic IO input counter” (2 bit counter) has detected an error. The input data has not been refreshed for at least 3 NC SAF cycles (the 2 bit counter displays a constant value for multiple NC SAF cycles, instead of incrementing by exactly one from cycle to cycle).");
            new ErrorCode(List,17513, ErrorType.Monitoring, @"Invalid IO Input Data (Error Type 2)
The monitoring of the “cyclic IO input counter” (2 bit counter) has detected an error. The quality of input data based on this two bit counter is not sufficient (there is here a simple statistic evaluation that evaluates GOOD cases and BAD cases and in exceeding a special limit value leads to an error).");
            new ErrorCode(List,17520, ErrorType.Monitoring, @"""SSI transformation fault or not finished"" The SSI transformation of the FOX 50 module was faulty for some NC-cycles or did not finished respectively.");
            new ErrorCode(List,17570, ErrorType.Monitoring, @"""ENCERR_ADDR_CONTROLLER""");
            new ErrorCode(List,17571, ErrorType.Monitoring, @"""ENCERR_INVALID_CONTROLLERTYPE""");


            #endregion

            #region Controller Errors

            new ErrorCode(List,17664, ErrorType.Parameter, @"""Controller ID not allowed"" The value for the controller ID is not allowed, e.g. because it has already been assigned, is less than or equal to zero, or is greater than 255.");

            new ErrorCode(List,17665, ErrorType.Parameter, @"""Controller type not allowed"" The value for the controller type is unacceptable because it is not defined. Type 1: P-controller (position) . . . Type 7: High/low speed controller Type 8: Stepper motor controller Type 9: Sercos controller");

            new ErrorCode(List,17666, ErrorType.Parameter, @"""Controller operating mode not allowed"" The value for the controller operating mode is not allowed.");

            new ErrorCode(List,17667, ErrorType.Parameter, @"""Weighting of the velocity pre-control not allowed"" The value for the percentage weighting of the velocity pre-control is not allowed. The parameter is pre-set to 1.0 (100%) as standard.");

            new ErrorCode(List,17668, ErrorType.Parameter, @"""Following error monitoring (position) not allowed"" The value for the activation of the following error monitoring is not allowed.");

            new ErrorCode(List,17669, ErrorType.Parameter, @"""Following error (velocity) not allowed"" The value for the activation of the following error monitoring (velocity) is not allowed.");

            new ErrorCode(List,17670, ErrorType.Parameter, @"""Following error window (position) not allowed"" The value for the following error window (maximum allowable following error) is not allowed.");

            new ErrorCode(List,17671, ErrorType.Parameter, @"""Following error filter time (position) not allowed"" The value for the following error filter time (position) is not allowed.");

            new ErrorCode(List,17672, ErrorType.Parameter, @"""Following error window (velocity) not allowed"" The value for the following error window (velocity) is not allowed.");

            new ErrorCode(List,17673, ErrorType.Parameter, @"""Following error filter time (velocity) not allowed"" The value for the following error filter time (velocity) is not allowed.");

            new ErrorCode(List,17680, ErrorType.Parameter, @"""Proportional gain Kv or Kp (controller) not allowed"" position The value for the proportional gain (Kv factor or Kp factor) is not allowed.");

            new ErrorCode(List,17681, ErrorType.Parameter, @"""Integral-action time Tn (controller) not allowed"" position The value for the integral-action time is not allowed (I proportion of the PID T1 controller).");

            new ErrorCode(List,17682, ErrorType.Parameter, @"""Derivative action time Tv (controller) not allowed"" position The value for the derivative action time is not allowed (D proportion of the PID T1 controller).");

            new ErrorCode(List,17683, ErrorType.Parameter, @"""Damping time Td (controller) not allowed"" position The value for the damping time is not allowed (D proportion of the PID T1 controller). Suggested value: 0.1 * Tv");

            new ErrorCode(List,17684, ErrorType.Function, @"""Activation of the automatic offset compensation not allowed"" Activation of the automatic offset compensation is only possible for certain types of controller (with no I component).");
            new ErrorCode(List,17685, ErrorType.Parameter, @"""Additional proportional gain Kv or Kp (controller) not allowed"" position The value for the second term of the proportional gain (Kv factor or Kp factor) is not allowed.");

            new ErrorCode(List,17686, ErrorType.Parameter, @"""Reference velocity for additional proportional gain Kv or Kp (controller) not allowed"" position The value for the reference velocity percentage data entry, to which the additional proportional gain is applied, is not allowed. The standard setting for the parameter is 0.5 (50%).");

            new ErrorCode(List,17687, ErrorType.Parameter, @"""Proportional gain Pa (proportion) not allowed"" acceleration The value for the proportional gain (Pa factor) is not allowed.");

            new ErrorCode(List,17688, ErrorType.Parameter, @"""Proportional gain Kv (velocity controller) not allowed"" The value for the proportional gain (Kv factor) is not allowed.");

            new ErrorCode(List,17689, ErrorType.Parameter, @"“Reset time Tn (velocity controller) not allowed” The value for the integral-action time is not allowed (I proportion of the PID T1 controller).");

            new ErrorCode(List,17690, ErrorType.Address, @"""CONTROLERR_RANGE_ACCJUMPLIMITINGMODE""");
            new ErrorCode(List,17691, ErrorType.Address, @"""CONTROLERR_RANGE_ACCJUMPVALUE""");
            new ErrorCode(List,17692, ErrorType.Address, @"""CONTROLERR_RANGE_FILTERTIME""");
            new ErrorCode(List,17693, ErrorType.Parameter, @"„Dead zone not allowed“ The value for the dead zone from the position error or the velocity error (system deviation) is not allowed (only for complex controller with velocity or torque interface).");

            new ErrorCode(List,17696, ErrorType.Parameter, @"”Rate time Tv (velocity controller) not allowed” The value for the derivative action time is not allowed (D proportion of the PID T1 controller).");

            new ErrorCode(List,17697, ErrorType.Parameter, @"""Damping time Td (velocity controller) not allowed"" The value for the damping time is not allowed (D proportion of the PID T1 controller). Suggested value: 0.1 * Tv");

            new ErrorCode(List,17698, ErrorType.Parameter, @"""CONTROLERR_RANGE_IOUTPUTLIMIT""");
            new ErrorCode(List,17699, ErrorType.Parameter, @"""CONTROLERR_RANGE_DOUTPUTLIMIT""");
            new ErrorCode(List,17700, ErrorType.Parameter, @"""CONTROLERR_RANGE_POSIDISABLEWHENMOVING""");
            new ErrorCode(List,17728, ErrorType.Initialization, @"""Controller initialization"" Controller has not been initialized. Although the controller has been created, the rest of the initialization has not been performed (1. Initialization of controller, 2. Reset controller).");
            new ErrorCode(List,17729, ErrorType.Address, @"""Axis address"" Controller does not know its axis, or the axis address has not been initialized.");
            new ErrorCode(List,17730, ErrorType.Address, @"""Drive address"" Controller does not know its drive, or the drive address has not been initialized.");
            new ErrorCode(List,17744, ErrorType.Monitoring, @"""Following error monitoring (position)"" With active following error monitoring (position) a following error exceedance has occurred, whose magnitude is greater than the following error window, and whose duration is longer than the parameterized following error filter time.");
            new ErrorCode(List,17745, ErrorType.Monitoring, @"""Following error monitoring (velocity)"" With active following error monitoring (velocity) a velocity following error exceedance has occurred, whose magnitude is greater than the following error window, and whose duration is longer than the parameterized following error filter time.");
            new ErrorCode(List,17824, ErrorType.Monitoring, @"""CONTROLERR_RANGE_AREA_ASIDE""");
            new ErrorCode(List,17825, ErrorType.Monitoring, @"""CONTROLERR_RANGE_AREA_BSIDE""");
            new ErrorCode(List,17826, ErrorType.Monitoring, @"""CONTROLERR_RANGE_QNENN""");
            new ErrorCode(List,17827, ErrorType.Monitoring, @"""CONTROLERR_RANGE_PNENN""");
            new ErrorCode(List,17828, ErrorType.Monitoring, @"""CONTROLERR_RANGE_AXISIDPRESP0""");

            #endregion

            #region Drive Errors

            new ErrorCode(List,17920, ErrorType.Parameter, @"‘""Drive ID not allowed"" The value for the drive ID is not allowed, e.g. because it has already been assigned, is less than or equal to zero, or is greater than 255.");

            new ErrorCode(List,17921, ErrorType.Parameter, @"‘Drive type impermissible’ The value for the drive type is impermissible, since it is not defined.");

            new ErrorCode(List,17922, ErrorType.Parameter, @"‘Drive operating mode impermissible’ The value for the drive operating mode is impermissible (mode 1: standard).");

            new ErrorCode(List,17923, ErrorType.Parameter, @"""Motor polarity inverted?"" The flag for the motor polarity is not allowed. Flag 0: Positive motor polarity flag 1: Negative motor polarity");

            new ErrorCode(List,17924, ErrorType.Parameter, @"‘Drift compensation/speed offset (DAC offset)’ The value for the drift compensation (DAC offset) is impermissible.");

            new ErrorCode(List,17925, ErrorType.Parameter, @"‘Reference speed (velocity pre-control)’ The value for the reference speed (also called velocity pilot control) is impermissible.");

            new ErrorCode(List,17926, ErrorType.Parameter, @"‘Reference output in percent’ The value for the reference output in percent is impermissible. The value 1.0 (100 %) usually corresponds to a voltage of 10.0 V.");

            new ErrorCode(List,17927, ErrorType.Parameter, @"‘Quadrant compensation factor’ The value for the quadrant compensation factor is impermissible.");

            new ErrorCode(List,17928, ErrorType.Parameter, @"‘Velocity reference point’ The value for the velocity reference point in percent is impermissible. The value 1.0 corresponds to 100 percent.");

            new ErrorCode(List,17929, ErrorType.Parameter, @"‘Output reference point’ The value for the output reference point in percent is impermissible. The value 1.0 corresponds to 100 percent.");

            new ErrorCode(List,17930, ErrorType.Parameter, @"‘Minimum or maximum output limits (output limitation)’ The value for the minimum and/or maximum output limit is impermissible. This will happen if the range of values is exceeded, the maximum limit is smaller than the minimum limit, or the distance between the minimum and maximum limits is zero. The minimum limit is initially set to –1.0 (-100 percent) and the maximum limit to 1.0 (100 percent).");

            new ErrorCode(List,17931, ErrorType.Parameter, @"“DRIVEERR_RANGE_MAXINCREMENT”");
            new ErrorCode(List,17932, ErrorType.Parameter, @"“DRIVEERR_RANGE_ DRIVECONTROLDWORD”");
            new ErrorCode(List,17933, ErrorType.Parameter, @"“DRIVEERR_RANGE_ RESETCYCLECOUNTER”");
            new ErrorCode(List,17935, ErrorType.Parameter, @"‘Drive torque output scaling impermissible’ The value is impermissible as drive torque output scaling (rotary motor) or as force output scaling (linear motor).");

            new ErrorCode(List,17936, ErrorType.Parameter, @"„Drive velocity output scaling is not allowed“ The value for the drive velocity output scaling is not allowed.");

            new ErrorCode(List,17937, ErrorType.Parameter, @"‘Profi Drive DSC proportional gain Kpc (controller) impermissible’ Positions The value for the Profi Drive DSC position control gain (Kpc factor) is impermissible.");

            new ErrorCode(List,17938, ErrorType.Parameter, @"‘Table ID is impermissible’ The value for the table ID is impermissible.");

            new ErrorCode(List,17939, ErrorType.Parameter, @"‘Table interpolation type is impermissible’ The value is impermissible as the table interpolation type.");

            new ErrorCode(List,17940, ErrorType.Parameter, @"‘Output offset in percent is impermissible’ The value is impermissible as an output offset in percent (+/- 1.0).");

            new ErrorCode(List,17941, ErrorType.Parameter, @"‘Profi Drive DSC scaling for calculation of “Xerr” (controller) impermissible’ Positions: the value is impermissible as Profi Drive DSC scaling for the calculation of ‘Xerr’.");

            new ErrorCode(List,17942, ErrorType.Parameter, @"‘Drive acceleration output scaling impermissible’ The value is impermissible as drive acceleration/deceleration output scaling.");

            new ErrorCode(List,17943, ErrorType.Parameter, @"‘Drive position output scaling impermissible’ The value is impermissible as drive position output scaling.");

            new ErrorCode(List,17948, ErrorType.Parameter, @"‘Drive filter type impermissible for command variable filter for the output position’ The value is impermissible as a drive filter type for the smoothing of the output position (command variable filter for the setpoint position).");

            new ErrorCode(List,17949, ErrorType.Parameter, @"‘Drive filter time impermissible for command variable filter for the output position’ The value is impermissible as a drive filter time for the smoothing of the output position (command variable filter for the setpoint position).");

            new ErrorCode(List,17950, ErrorType.Parameter, @"‘Drive filter order impermissible for command variable filter for the output position’ The value is impermissible as a drive filter order (P-Tn) for the smoothing of the output position (command variable filter for the setpoint position).");

            new ErrorCode(List,17952, ErrorType.Parameter, @"‘Bit mask for stepper motor cycle impermissible’ A value of the different stepper motor masks is impermissible for the respective cycle.");

            new ErrorCode(List,17953, ErrorType.Parameter, @"‘Bit mask for stepper motor holding current impermissible’ The value for the stepper motor holding mask is impermissible.");

            new ErrorCode(List,17954, ErrorType.Parameter, @"‘Scaling factor for actual torque (actual current) impermissible’ The value is impermissible as a scaling factor for the actual torque (or actual current).");

            new ErrorCode(List,17955, ErrorType.Parameter, @"‘Filter time for actual torque is impermissible’ The value is impermissible as a filter time for the actual torque (or the actual current) (P-T1 filter).");

            new ErrorCode(List,17956, ErrorType.Parameter, @"‘Filter time for the temporal derivation of the actual torque is impermissible’ The value is impermissible as a filter time for the temporal derivation of the actual torque (or actual current (P-T1 filter).");

            new ErrorCode(List,17959, ErrorType.Function, @"DRIVEOPERATIONMODEBUSY. The activation of the drive operation mode failed, because another object with OID ... is already using this interface.");

            new ErrorCode(List,17968, ErrorType.Monitoring, @"‘Overtemperature’ Overtemperature was detected or reported in the drive or terminal.");
            new ErrorCode(List,17969, ErrorType.Monitoring, @"‘Undervoltage’ Undervoltage was detected or reported in the drive or terminal.");
            new ErrorCode(List,17970, ErrorType.Monitoring, @"‘Wire break in phase A’ A wire break in phase A was detected or reported in the drive or terminal.");
            new ErrorCode(List,17971, ErrorType.Monitoring, @"‘Wire break in phase B’ A wire break in phase B was detected or reported in the drive or terminal.");
            new ErrorCode(List,17972, ErrorType.Monitoring, @"‘Overcurrent in phase A’ Overcurrent was detected or reported in phase A in the drive or terminal.");
            new ErrorCode(List,17973, ErrorType.Monitoring, @"‘Overcurrent in phase B’ Overcurrent was detected or reported in phase B in the drive or terminal.");
            new ErrorCode(List,17974, ErrorType.Monitoring, @"‘Torque overload (stall)’ A torque overload (stall) was detected or reported in the drive or terminal.");
            new ErrorCode(List,17984, ErrorType.Initialization, @"‘Drive initialization’ Drive has not been initialized. Although the drive has been created, the rest of the initialization has not been performed (1. Initialization of drive I/O, 2. Initialization of drive, 3. Reset drive).");
            new ErrorCode(List,17985, ErrorType.Address, @"‘Axis address’ Drive does not know its axis, or the axis address has not been initialized.");
            new ErrorCode(List,17986, ErrorType.Address, @"‘Address IO input structure’ Drive has no valid IO input address in the process image.");
            new ErrorCode(List,17987, ErrorType.Address, @"‘Address IO output structure’ Drive has no valid IO output address in the process image.");
            new ErrorCode(List,18000, ErrorType.Monitoring, @"‘Drive hardware not ready to operate’ The drive hardware is not ready for operation. The following are possible causes:
- the drive is in the error state (hardware error)
- the drive is in the start-up phase (e.g. after an axis reset that was preceded by a hardware error)
- the drive is missing the controller enable (ENABLE)
Note: The time required for ""booting"" a drive after a hardware fault can amount to several seconds.");
            new ErrorCode(List,18001, ErrorType.Monitoring, @"Error in the cyclic communication of the drive (Life Counter). Reasons for this could be an interrupted fieldbus or a drive that is in the error state.");
            new ErrorCode(List,18002, ErrorType.Monitoring, @"‘Changing the table ID when active controller enable is impermissible’. Changing (deselecting, selecting) the characteristic curve table ID is not permissible when the controller enable for the axis is active.");
            new ErrorCode(List,18005, ErrorType.Monitoring, @"‘Invalid IO data for more than ‘n’ continuous NC cycles’ The axis (encoder or drive) has detected invalid IO data (e.g. n=3) for more than ‘n’ continuous NC cycles (NC SAF task).
EtherCAT fieldbus: ‘working counter error ('WCState')’As a result it is possible that the encoder referencing flag will be reset to FALSE (i.e. the encoder is given the status ‘unreferenced’).
Lightbus fieldbus: ‘CDL state error ('CdlState')’
As a result it is possible that the encoder calibration flag will set to FALSE (that means uncalibrated).");

            #endregion

            #region Table Errors

            new ErrorCode(List,18944, ErrorType.Parameter, @"""Table ID not allowed"" The value for the table ID is not allowed, e.g. because it has already been assigned, is less than or equal to zero, or is greater than 255.");

            new ErrorCode(List,18945, ErrorType.Parameter, @"""Table type not allowed"" The value for the table type is unacceptable because it is not defined.");

            new ErrorCode(List,18946, ErrorType.Parameter, @"""Number of lines in the table not allowed"" The value of the number of lines in the table is not allowed, because, for example, it is smaller than two at linear interpolation and smaller than four at spline interpolation.");

            new ErrorCode(List,18947, ErrorType.Parameter, @"""Number of columns in the table is not allowed"" The value of the number of columns in the table is not allowed, because, for example, it is less than or equal to zero (depends upon the type of table or slave).");

            new ErrorCode(List,18948, ErrorType.Parameter, @"""Step size (position delta) not allowed"" The value for the step size between two lines (position delta) is not allowed, because, for example, it is less than or equal to zero.");

            new ErrorCode(List,18949, ErrorType.Parameter, @"""Period not allowed"" The value for the period is not allowed, because, for example, it is less than or equal to zero.");

            new ErrorCode(List,18950, ErrorType.Parameter, @"""Table is not monotonic"" The value for the step size is not allowed, because, for example, it is less than or equal to zero.");
            new ErrorCode(List,18951, ErrorType.Initialization, @"„Table sub type is not allowed“ The value for the table sub type is not allowed or otherwise the table class (slave type) do not match up to the table main type. Table sub type: (1) equidistant linear position table, (2) equidistant cyclic position table, (3) none equidistant linear position table, (4) none equidistant cyclic position table");

            new ErrorCode(List,18952, ErrorType.Initialization, @"„Table interpolation type is not allowed“ The value for the table interpolation type is allowed. Table interpolation type: (0) linear-interpolation, (1) 4-point-interpolation, (2) spline-interpolation");

            new ErrorCode(List,18953, ErrorType.Initialization, @"""Incorrect table main type"" The table main type is unknown or otherwise the table class (slave type) do not match up to the table main type. Table main type: (1) camming table, (2) characteristic table, (3) 'motion function' table (MF)");
            new ErrorCode(List,18960, ErrorType.Initialization, @"""Table initialization"" Table has not been initialized. Although the table has been created, the rest of the initialization has not been performed. For instance, the number of lines or columns may be less than or equal to zero.");
            new ErrorCode(List,18961, ErrorType.Initialization, @"""Not enough memory"" Table could not be created, since there is not enough memory.");
            new ErrorCode(List,18962, ErrorType.Function, @"""Function not executed, function not available"" The function has not been implemented, or cannot be executed, for the present type of table.");
            new ErrorCode(List,18963, ErrorType.Function, @"""Line index not allowed"" The start line index or the stop line index to be used for read or write access to the table is not allowed. For instance, the line index may be greater than the total number of lines in the table.");
            new ErrorCode(List,18964, ErrorType.Function, @"""Column index not allowed"" The start column index or the stop column index to be used for read or write access to the table in not allowed. For instance, the column index may be greater than the total number of columns in the table.");
            new ErrorCode(List,18965, ErrorType.Function, @"""Number of lines not allowed"" The number of lines to be read from or written to the table is not allowed. The number of lines must be an integer multiple of the number of elements in a line (n * number of columns).");
            new ErrorCode(List,18966, ErrorType.Function, @"""Number of columns not allowed"" The number of columns to be read from or written to the table is not allowed. The number of columns must be an integer multiple of the number of elements in a column (n * number of lines).");
            new ErrorCode(List,18967, ErrorType.Function, @"""Error in scaling or in range entry"" The entries in the table header are inconsistent, e.g. the validity range is empty. If the error is generated during the run time it is a run time error and stops the master/slave group.");
            new ErrorCode(List,18968, ErrorType.Function, @"""Multi table slave out of range"" The slave master position is outside the table values for the master. The error is a run-time error, and stops the master/slave group.");
            new ErrorCode(List,18969, ErrorType.Function, @"""Solo table underflow"" The slave master position is outside the table values for the master. The master value of the equidistant table, to be processed linearly, lies under the first table value. The error is a run-time error, and stops the master/slave group.");
            new ErrorCode(List,18970, ErrorType.Function, @"""Solo table overflow"" The slave master position is outside the table values for the master. The master value of the equidistant table, to be processed linearly, lies above the first table value. The error is a run-time error, and stops the master/slave group.");
            new ErrorCode(List,18971, ErrorType.Parameter, @"""Incorrect execution mode"" The cyclic execution mode can only be ""true"" or ""false"".");
            new ErrorCode(List,18972, ErrorType.Parameter, @"""Impermissible parameter"" The Fifo parameter is not allowed.");
            new ErrorCode(List,18973, ErrorType.Parameter, @"""Fifo is empty"" The Fifo of the external generator is empty. This can signify end of track or a run time error.");
            new ErrorCode(List,18974, ErrorType.Parameter, @"""Fifo is full"" The Fifo of the external generator is full. It is the user‘s task to continue to attempt to fill the Fifo with the rejected values.");
            new ErrorCode(List,18975, ErrorType.Parameter, @"„Point-Index of Motion Function invalid“ The point index of a Motion Function Point of a Function Table is invalid. First the point index has to be larger than zero and second it has to be numerical continuously for one column in the Motion Function Table (e.g. 1,2,3,... or 10,11,12,...).
Remark: The point index is not online-changeable but must be constant.");
            new ErrorCode(List,18976, ErrorType.Initialization, @"„No diagonalization of matrix“ The spline can not be calculated. The master positions are not correct.");
            new ErrorCode(List,18977, ErrorType.Initialization, @"„Number of spline points to less“ The number of points of a cubic spline has to be greater than two.");
            new ErrorCode(List,18978, ErrorType.Initialization, @"„Fifo must not be overwritten“ Fifo must not be overwritten since then the active line would be overwritten. It is the task of the user to secure that the active line is not modified.");
            new ErrorCode(List,18979, ErrorType.Function, @"„Insufficient number of Motion Function points“ The number of valid Motion Function points is less than two. Either the entire number of points is to low or the point type of many points is set to Ignore Point.");

            #endregion

            #region NC-PLC Errors

            new ErrorCode(List,19200, ErrorType.Parameter, @"""Axis was stopped"" The axis was stopped during travel to the target position. The axis may have been stopped with a PLC command via ADS, a call via AXFNC, or by the System Manager.");
            new ErrorCode(List,19201, ErrorType.Parameter, @"""Axis cannot be started"" The axis cannot be started because:
▪
the axis is in error status,
▪
the axis is executing another command,
▪
the axis is in protected mode,
▪
the axis is not ready for operation.");
            new ErrorCode(List,19202, ErrorType.Parameter, @"""Control mode not permitted"" No target position control, and no position range control.");
            new ErrorCode(List,19203, ErrorType.Parameter, @"""Axis is not moving"" The position and velocity can only be restarted while the axis is physically in motion.");
            new ErrorCode(List,19204, ErrorType.Parameter, @"""Wrong mode for RestartPosAndVelo"" Wrong mode.");
            new ErrorCode(List,19205, ErrorType.Parameter, @"""Command not permitted""
▪
Continuous motion in an unspecified direction
▪
Read/Write parameters: type mismatch");
            new ErrorCode(List,19206, ErrorType.Parameter, @"""Parameter incorrect""
▪
Incorrect override: > 100% or < 0%
▪
Incorrect gear ratio: RatioDenominator = 0");
            new ErrorCode(List,19207, ErrorType.Parameter, @"""Timeout axis function block""
After positioning, all ""MC_Move..."" blocks check whether positioning was completed successfully. In the simplest case, the ""AxisHasJob"" flag of the NC axis is checked, which initially signifies that positioning was logically completed. Depending on the parameterization of the NC axis, further checks (quality criteria) are used:
▪
""Position range monitoring""
If position range monitoring is active, the system waits for feedback from the NC. After positioning, the axis must be within the specified positioning range window. If necessary, the position controller ensures that the axis is moved to the target position. If the position controller is switched off (Kv=0) or weak, the target may not be reached.
▪
""Target position monitoring""
If target position monitoring is active, the system waits for feedback from the NC. After positioning, the axis must be within the specified target position window for at least the specified time. If necessary, the position controller ensures that the axis is moved to the target position. If the position controller is switched off (Kv=0) or weak, the target may not be reached. Floating position control may lead to the axis oscillating around the window but not remaining inside the window.
If the axis is logically at the target position (logical standstill) but the parameterized position window has not been reached, monitoring of the above-mentioned NC feedback is aborted with error 19207 (0x4B07) after a constant timeout of 6 seconds.");
            new ErrorCode(List,19208, ErrorType.Parameter, @"""Axis is in protected mode"" The axis is in protected mode ( e.g. coupled) and cannot be moved.");
            new ErrorCode(List,19209, ErrorType.Parameter, @"""Axis is not ready"" The axis is not ready and cannot be moved.");
            new ErrorCode(List,19210, ErrorType.Parameter, @"""Error during referencing"" Referencing (homing) of the axis could not be started or was not successful.");
            new ErrorCode(List,19211, ErrorType.Parameter, @"""Incorrect definition of the trigger input"" The definition of the trigger signal for block MC_TouchProbe is incorrect. The defined encoder-ID, the trigger signal or the trigger edge are invalid.");
            new ErrorCode(List,19212, ErrorType.Function, @"""Position latch was disabled"" The function block MC_TouchProbe has detected that a measuring probe cycle it had started was disabled. The reason may be an axis reset, for example.");
            new ErrorCode(List,19213, ErrorType.Function, @"‘NC status feedback timeout’ A function was successfully sent from the PLC to the NC. An expected feedback in the axis status word has not arrived.");
            new ErrorCode(List,19214, ErrorType.Function, @"""Additional product not installed"" The function is available as an additional product but is not installed on the system.");
            new ErrorCode(List,19215, ErrorType.Function, @"""No NC Cycle Counter Update"" – The NcToPlc Interface or the NC Cycle Counter in the NcToPlc Interface was not updated.");

            new ErrorCode(List,19216, ErrorType.Function, @"""M-function query missing"" This error occurs if the M-function was confirmed, but the request bit was not set.");
            new ErrorCode(List,19217, ErrorType.Parameter, @"""Zero offset index is outside the range"" The index of the zero offset is invalid.");
            new ErrorCode(List,19218, ErrorType.Parameter, @"""R-parameter index or size is invalid"" This error occurs if the R-parameters are written or read but the index or size are outside the range.");
            new ErrorCode(List,19219, ErrorType.Parameter, @"""Index for tool description is invalid""");
            new ErrorCode(List,19220, ErrorType.Function, @"""Version of the cyclic channel interface does not match the requested function or the function block"" This error occurs if an older TwinCAT version is used to call new functions of a later TcNci.lib version.");
            new ErrorCode(List,19221, ErrorType.Function, @"""Channel is not ready for the requested function"" The requested function cannot be executed, because the channel is in the wrong state. This error occurs during reverse travel, for example, if the axis was not stopped with ItpEStop first.");
            new ErrorCode(List,19222, ErrorType.Function, @"""Requested function is not activated"" The requested function requires explicit activation.");
            new ErrorCode(List,19223, ErrorType.Function, @"""Axis is already in another group"" The axis has already been added to another group.");
            new ErrorCode(List,19224, ErrorType.Function, @"""Block search could not be executed successfully"" The block search has failed.
Possible causes:
▪
Invalid block number");
            new ErrorCode(List,19225, ErrorType.Parameter, @"""Invalid block search parameter"" This error occurs if the FB ItpBlocksearch is called with invalid parameters (e.g. E_ItpDryRunMode, E_ItpBlockSearchMode)");
            new ErrorCode(List,19232, ErrorType.Function, @"""Cannot add all axes"" This error occurs if an auxiliary axis is to be added to an interpolation group, but the function fails. It is likely that a preceding instruction of an auxiliary axis was skipped.");

            new ErrorCode(List,19248, ErrorType.Parameter, @"""Pointer is invalid"" A pointer to a data structure is invalid, e.g. Null,
▪
Data structure MC_CAM_REF was not initialized");
            new ErrorCode(List,19249, ErrorType.Parameter, @"""Memory size invalid"" The specification of the memory size (SIZE) for a data structure is invalid.
▪
The value of the size parameter is 0 or less than the size of one element of the addressed data structure.
▪
The value of the size parameter is less than the requested amount of data.
▪
The value of the size parameter does not match other parameters as number of points, number of rows or number of columns.");
            new ErrorCode(List,19250, ErrorType.Parameter, @"""Cam table ID is invalid"" The ID of a cam table is not between 1 and 255.");
            new ErrorCode(List,19251, ErrorType.Parameter, @"""Point ID is invalid"" The ID of a point (sampling point) of a motion function is less than 1.");
            new ErrorCode(List,19252, ErrorType.Parameter, @"""Number of points is invalid"" The number of points (sampling points) of a cam plate to be read or written is less than 1.");
            new ErrorCode(List,19253, ErrorType.Parameter, @"""MC table type is invalid"" The type of a cam plate does not match the definition MC_TableType.");
            new ErrorCode(List,19254, ErrorType.Parameter, @"""Number of rows invalid"" The number of rows (sampling points) of a cam table is less than 1.");
            new ErrorCode(List,19255, ErrorType.Parameter, @"""Number of columns invalid"" The number of columns of a cam table is invalid.
▪
The number of columns of a motion function is not equal 1
▪
The number of columns of a standard cam table is not equal 2
▪
The number of columns does not match another parameter (ValueSelectMask)");
            new ErrorCode(List,19256, ErrorType.Parameter, @"""Step size invalid"". The increment for the interpolation is invalid, e.g. less than or equal to zero.");

            new ErrorCode(List,19264, ErrorType.Monitoring, @"""Terminal type not supported"" The terminal used is not supported by this function block.");
            new ErrorCode(List,19265, ErrorType.Monitoring, @"""Register read/write error"" This error implies a validity error.");
            new ErrorCode(List,19266, ErrorType.Monitoring, @"""Axis is enabled"" The axis is enabled but should not be enabled for this process.");
            new ErrorCode(List,19267, ErrorType.Parameter, @"""Incorrect size of the compensation table"" The specified table size (in bytes) does not match the actual size");
            new ErrorCode(List,19268, ErrorType.Parameter, @"The minimum/maximum position in the compensation table does not match the position in the table description (ST_CompensationDesc)");
            new ErrorCode(List,19269, ErrorType.Parameter, @"""Not implemented"" The requested function is not implemented in this combination");


            new ErrorCode(List,19296, ErrorType.Monitoring, @"""Motion command did not become active"" A motion command has been started and has been buffered and confirmed by the NC. Nevertheless, the motion command did not become active (possibly due to a terminating condition or an internal NC error).");
            new ErrorCode(List,19297, ErrorType.Monitoring, @"""Motion command could not be monitored by the PLC"" A motion command has been started and has been buffered and confirmed by the NC. The PLC has not been able to monitor the execution of this command and the execution status is unclear since the NC is already executing a more recent command. The execution state is unclear. This error may come up with very short buffered motion commands which are executed during one PLC cycle.");
            new ErrorCode(List,19298, ErrorType.Monitoring, @"""Buffered command was terminated with an error"" A buffered command was terminated with an error. The error number is not available, because a new command is already being executed.");
            new ErrorCode(List,19299, ErrorType.Monitoring, @"""Buffered command was completed without feedback"" A buffered command was completed but there was no feedback to indicate success or failure.");
            new ErrorCode(List,19300, ErrorType.Monitoring, @""" 'BufferMode' is not supported by the command"" The 'BufferMode' is not supported by this command.");
            new ErrorCode(List,19301, ErrorType.Monitoring, @"""Command number is zero"" The command number for queued commands managed by the system unexpectedly has the value 0.");
            new ErrorCode(List,19302, ErrorType.Monitoring, @"""Function block was not called cyclically"" The function block was not called cyclically. The command execution could not be monitored by the PLC, because the NC was already executing a subsequent command. The execution state is unclear.");

            new ErrorCode(List,19313, ErrorType.Parameter, @"""Invalid NCI entry type"". The FB FB_NciFeedTablePreparation was called with an unknown nEntryType.");
            new ErrorCode(List,19314, ErrorType.Function, @"""NCI feed table full"" The table is full, and the entry is therefore not accepted.
Remedy:
Transfer the context of the table with FB_NciFeedTable to the NC-Kernel. If bFeedingDone = TRUE, the table can be reset in FB_NciFeedTablePreparation with bResetTable and then filled with new entries.");
            new ErrorCode(List,19315, ErrorType.Function, @"internal error");
            new ErrorCode(List,19316, ErrorType.Parameter, @"""ST_NciTangentialFollowingDesc: tangential axis is not an auxiliary axis"" The entry for tangential following contains a tangential axis that is not an auxiliary axis.");
            new ErrorCode(List,19317, ErrorType.Parameter, @"ST_NciTangentialFollowingDesc: nPathAxis1 or nPathAxis2 is not a path axis. It is therefore not possible to determine the plane.");
            new ErrorCode(List,19318, ErrorType.Parameter, @"ST_NciTangentialFollwoingDesc: nPathAxis1 and nPathAxis2 are the same. It is therefore not possible to determine the plane.");
            new ErrorCode(List,19319, ErrorType.Parameter, @"ST_NciGeoCirclePlane: Circle incorrectly parameterized");
            new ErrorCode(List,19320, ErrorType.Function, @"Internal error during calculation of tangential following");
            new ErrorCode(List,19321, ErrorType.Monitoring, @"Tangential following: Monitoring of the deviation angle was activated during activation of tangential following (E_TfErrorOnCritical1), and an excessively large deviation angle was detected in the current segment.");
            new ErrorCode(List,19322, ErrorType.Function, @"not implemented");
            new ErrorCode(List,19323, ErrorType.Parameter, @"Tangential following: the radius of the current arc is too small");
            new ErrorCode(List,19324, ErrorType.Parameter, @"FB_NciFeedTablePreparation: pEntry is Null,");
            new ErrorCode(List,19325, ErrorType.Parameter, @"FB_NciFeedTablePreparation: the specified nEntryType does not match the structure type");
            new ErrorCode(List,19326, ErrorType.Parameter, @"ST_NciMFuncFast and ST_NciMFuncHsk: the requested M-function is not between 0 and 159");
            new ErrorCode(List,19327, ErrorType.Parameter, @"ST_NciDynOvr: the requested value for the dynamic override is not between 0.01 and 1");
            new ErrorCode(List,19328, ErrorType.Parameter, @"ST_NciVertexSmoothing: invalid parameter. This error is generated if a negative smoothing radius or an unknown smoothing type is encountered.");
            new ErrorCode(List,19329, ErrorType.Parameter, @"FB_NciFeedTablePrepartion: The requested velocity is not in the valid range");
            new ErrorCode(List,19330, ErrorType.Parameter, @"ST_Nci*: invalid parameter");

            new ErrorCode(List,19360, ErrorType.Function, @"KinGroup error: the kinematic group is in an error state.
This error may occur if the kinematic group is in an error state or an unexpected state when it is called (e.g. simultaneous call via several FB instances).");
            new ErrorCode(List,19361, ErrorType.Function, @"KinGroup timeout: timeout during call of a kinematic block");

            new ErrorCode(List,19344, ErrorType.Parameter, @"Determined drive type is not supported");
            new ErrorCode(List,19345, ErrorType.Parameter, @"Direction is impermissible");
            new ErrorCode(List,19346, ErrorType.Null, @"SwitchMode is impermissible");
            new ErrorCode(List,19347, ErrorType.Null, @"Mode for the parameter handling is impermissible");
            new ErrorCode(List,19348, ErrorType.Null, @"Parameterization of the torque limits is inconsistent");
            new ErrorCode(List,19349, ErrorType.Null, @"Parameterization of the position lag limit is impermissible (<=0).");
            new ErrorCode(List,19350, ErrorType.Null, @"Parameterization of the distance limit is impermissible (<0)");
            new ErrorCode(List,19351, ErrorType.Null, @"An attempt was made to back up parameters again, although they have already been backed up.");
            new ErrorCode(List,19352, ErrorType.Null, @"An attempt was made to restore parameters, although none have been backed up.");

            new ErrorCode(List,19376, ErrorType.Function, @"The current axis position or the axis position resulting from the new position offset exceeds the valid range of values.");
            new ErrorCode(List,19377, ErrorType.Function, @"The new position offset exceeds the valid range of values [AX5000: 2^31]");
            new ErrorCode(List,19378, ErrorType.Function, @"The current axis position or the axis position resulting from the new position offset falls below the valid range of values.");
            new ErrorCode(List,19379, ErrorType.Function, @"The new position offset falls below the valid range of values [AX5000: -2^31]");
            new ErrorCode(List,19380, ErrorType.Function, @"The activated feedback and/or storage location (AX5000: P-0-0275) differ from the parameterization on the function block.");
            new ErrorCode(List,19381, ErrorType.Function, @"Reinitialisation of the Nc actual position has failed.
e.g. reference system = “ABSOLUTE (with single overflow)” & software end position monitoring is disabled.");



            #endregion

            #region Kinematic transformation

            new ErrorCode(List,19456, ErrorType.Null, @"Transformation failed.");
            new ErrorCode(List,19457, ErrorType.Null, @"Ambiguous answer. The answer of the transformation is not explicit.");
            new ErrorCode(List,19458, ErrorType.Null, @"Invalid axis position: The transformation can not be calculated with the current position data.
Possible causes:
▪
The position is outside the working area of the kinematics");
            new ErrorCode(List,19459, ErrorType.Configuration, @"Invalid dimension: The dimension of the paramerterized input parameter does not match the dimension expected by the kinematic object.
Possible causes:
▪
Too many position values are supplied for this configuration. Check the number of parameterized axes.");
            new ErrorCode(List,19460, ErrorType.Null, @"NCERR_KINTRAFO_REGISTRATION");
            new ErrorCode(List,19461, ErrorType.Internal, @"Newton iteration failed: The Newton iteration does not converge.");
            new ErrorCode(List,19462, ErrorType.Internal, @"Jacobi matrix cannot be inverted");
            new ErrorCode(List,19463, ErrorType.Configuration, @"Invalid cascade: This kinematic configuration is not permitted.");
            new ErrorCode(List,19464, ErrorType.Programming, @"Singularity: The machine configuration results in singular axis velocities.");
            new ErrorCode(List,19467, ErrorType.Internal, @"No metainfo: Metainfo pointer is null.");
            new ErrorCode(List,19488, ErrorType.Internal, @"Transformation failed: Call of extended kinematic model failed.");
            new ErrorCode(List,19504, ErrorType.Programming, @"Invalid input frame: Programmed Cartesian position cannot be reached in the ACS configuration.");
            new ErrorCode(List,19536, ErrorType.Internal, @"Invalid offset: Access violation detected in the observer.");

            #endregion

            #region Bode Return Codes

            new ErrorCode(List,33024, ErrorType.Symbol, @"Internal error");
            new ErrorCode(List,33025, ErrorType.Symbol, @"Not initialized (e.g. no nc axis)");
            new ErrorCode(List,33026, ErrorType.Symbol, @"Invalid parameter");
            new ErrorCode(List,33027, ErrorType.Symbol, @"Invalid index offset");
            new ErrorCode(List,33028, ErrorType.Symbol, @"Invalid parameter size");
            new ErrorCode(List,33029, ErrorType.Symbol, @"Invalid start parameter (set point generator)");
            new ErrorCode(List,33030, ErrorType.Symbol, @"Not supported");
            new ErrorCode(List,33031, ErrorType.Symbol, @"Nc axis not enabled");
            new ErrorCode(List,33032, ErrorType.Symbol, @"Nc axis in error state");
            new ErrorCode(List,33033, ErrorType.Symbol, @"IO drive in error state");
            new ErrorCode(List,33034, ErrorType.Symbol, @"Nc axis AND IO drive in error state");
            new ErrorCode(List,33035, ErrorType.Symbol, @"Invalid drive operation mode active or requested
(no bode plot mode)");
            new ErrorCode(List,33036, ErrorType.Symbol, @"Invalid context for this command (mandatory task or windows context needed)");
            new ErrorCode(List,33037, ErrorType.Symbol, @"Missing TCom axis interface (axis null pointer).
There is no connection to the NC axis.
Either no axis (or axis ID) has been parameterized, or the parameterized axis does not exist.");
            new ErrorCode(List,33038, ErrorType.Symbol, @"Invalid input cycle counter from IO drive (e.g. frozen).
The cyclic drive data are backed up by an ‘InputCycleCounter’ during the bode plot recording. This allows firstly the detection of an unexpected communication loss (keyword: LifeCounter) and secondly a check for temporal data consistency to be performed.
Sample 1: This error can occur if the cycle time of the calling task is larger than the assumed drive cycle time (in this case, however, the error occurs right at the start of the recording).
Sample 2: This error can occur if the calling task has real-time errors (e.g. the ""Exceed Counter"" of the task increments or the task has a lower priority, as is often the case, for example, with the PLC). In this case the error can also occur at any time during the recording.
Sample 3: This error can occur more frequently if the real-time load on the computer is quite high (>50 %).
Note: Refer also to the corresponding AX5000 drive error code F440.");
            new ErrorCode(List,33039, ErrorType.Symbol, @"Position monitoring: Axis position is outside of the maximum allowed moving range.
The axis has left the parameterized position range window, whereupon the recording was aborted and the NC axis was placed in the error state 0x810F (with standard NC error handling).
The position range window acts symmetrically around the initial position of the axis (see also parameter description Position Monitoring Window).
Typical error message in the logger:
""BodePlot: 'Position Monitoring' error 0x%x because the actual position %f is above the maximum limit %f of the allowed position range (StartPos=%f, Window=%f)""");
            new ErrorCode(List,33040, ErrorType.Symbol, @"Driver limitations detected (current or velocity limitations) which causes a nonlinear behavior and invalid results of the bode plot.
A bode plot recording requires an approximately linear transmission link. If the speed or current is limited in the drive unit, however, this non-linear behavior is detected and the bode plot recording is aborted. Reasons for these limitations can be: choosing too large an amplitude for the position, speed or torque interface, or an unsuitable choice of amplitude scaling mode (see also parameter description Amplitude Scaling Mode, Base Amplitude, Signal Amplitude).
Typical error message in the logger:
""BodePlot: Sequence aborted with error 0x%x because the current limit of the drive has been exceeded (%d times) which causes a nonlinear behavior and invalid results of the bode plot""");
            new ErrorCode(List,33041, ErrorType.Symbol, @"Life counter monitoring (heartbeat): Lost of communication to GUI detected after watchdog timeout is elapsed.
The graphical user interface from which the bode plot recording was started is no longer communicating with the bode plot driver in the expected rhythm (keyword: ‘Life Counter’). Therefore the recording is terminated immediately and the NC axes are placed in the error state 0x8111 (with standard NC error handling). Possible reasons for this can be an operating interface crash or a major malfunction of the Windows context.
Typical error message in the logger:
""BodePlot: Sequence aborted with GUI Life Counter error 0x%x because the WatchDog timeout of %f s elapsed ('%s')""");
            new ErrorCode(List,33042, ErrorType.Symbol, @"WC state error (IO data working counter)
IO working counter error (WC state), for example due to real-time errors, EtherCAT CRC errors or telegram failures, EtherCAT device not communicating (OP state), etc.");

            #endregion

            #region Further Error Codes

            new ErrorCode(List,33056, ErrorType.Environment, @"Invalid configuration for Object (e.g. in System Manager)");
            new ErrorCode(List,33057, ErrorType.Environment, @"Invalid environment for Object (e.g. TcCom-Object's Hierarchy or missing/faulty Objects)");
            new ErrorCode(List,33058, ErrorType.Environment, @"Incompatible Driver or Object");
            new ErrorCode(List,33077, ErrorType.Internal, @"Function Block Inputs are inconsitent.Some Inputs of the Function Block are inconsistent during. Probably Communicator and its IID, which both have to be set or unset.");
            new ErrorCode(List,33083, ErrorType.Parameter, @"Transition Mode is invalid");
            new ErrorCode(List,33084, ErrorType.Parameter, @"BufferMode is invalid");
            new ErrorCode(List,33085, ErrorType.FunctionBlock, @"Only one active Instance of Function Block per Group is allowed.");
            new ErrorCode(List,33086, ErrorType.State, @"Command is not allowed in current group state.");
            new ErrorCode(List,33087, ErrorType.FunctionBlock, @"Slave cannot synchronize.The slave cannot reach the SlaveSyncPosition by the time the master has reached the MasterSyncPos.");
            new ErrorCode(List,33088, ErrorType.Parameter, @"Invalid value for one or more of the dynamic parameters (A, D, J).");
            new ErrorCode(List,33089, ErrorType.Parameter, @"IdentInGroup is invalid.");
            new ErrorCode(List,33090, ErrorType.Parameter, @"The number of axes in the group is incompatible with the axes convention.");
            new ErrorCode(List,33091, ErrorType.Communication, @"Function Block or respective Command is not supported by Target.");
            new ErrorCode(List,33093, ErrorType.FunctionBlock, @"Mapping of Cyclic Interface between Nc and Plc missing (e.g. AXIS_REF, AXES_GROUP_REF, ...).");
            new ErrorCode(List,33094, ErrorType.FunctionBlock, @"Invalid Velocity ValueThe velocity was not set or the entered value is invalid");
            new ErrorCode(List,33096, ErrorType.FunctionBlock, @"Invalid Input Value");
            new ErrorCode(List,33097, ErrorType.Parameter, @"Unsupported Dynamics for selected Group Kernel");
            new ErrorCode(List,33098, ErrorType.Parameter, @"The programmed position dimension incompatible with the axes convention.");
            new ErrorCode(List,33099, ErrorType.FunctionBlock, @"Path buffer is invalid. E.g. because provided buffer has invalid address or is not big enough");
            new ErrorCode(List,33100, ErrorType.FunctionBlock, @"Path does not contain any element");
            new ErrorCode(List,33101, ErrorType.FunctionBlock, @"Provided Path buffer is too small to store more Path Elements");
            new ErrorCode(List,33102, ErrorType.Parameter, @"Dimension or at least one Value of Transition Parameters is invalid");
            new ErrorCode(List,33103, ErrorType.FunctionBlock, @"Invalid or Incomplete Input Array");
            new ErrorCode(List,33104, ErrorType.FunctionBlock, @"Path length is zero");
            new ErrorCode(List,33105, ErrorType.State, @"Command is not allowed in current axis state.");
            new ErrorCode(List,33106, ErrorType.State, @"TwinCAT System is shutting down and cannot complete request.");
            new ErrorCode(List,33120, ErrorType.NcProgramming, @"Circle Specification in Path is invalid.The specification of a circle segment in the programmed interpolated path (e.g. via MC_MovePath) has an invalid or ambiguous descripition. Probably its center cannot be determined reliably.");
            new ErrorCode(List,33121, ErrorType.NcProgramming, @"Maximum stream lines reached.The maximum number of stream lines is limited. Please refer to function block documentation for details.");
            new ErrorCode(List,33123, ErrorType.FunctionBlock, @"Invalid First Segment.The corresponding element can only be analyzed with a well-defined start point.");
            new ErrorCode(List,33124, ErrorType.FunctionBlock, @"Invalid auxiliary point.The auxiliary point is not well-defined.");
            new ErrorCode(List,33126, ErrorType.FunctionBlock, @"Invalid parameter for GapControlModeInvalid parameter for GapControlMode, most likely in combination with the group parameter GapControlDirection");
            new ErrorCode(List,33127, ErrorType.External, @"Group got unsupported Axis Event (e.g. State Change)Group got unsupported Axis Event (e.g. State Change e.g. triggered by a Single Axis Reset)");
            new ErrorCode(List,36726, ErrorType.Internal, @"Unexpected Internal Error");
            new ErrorCode(List,36857, ErrorType.Internal, @"Unexpected Internal Error");
            new ErrorCode(List,36859, ErrorType.Internal, @"Unexpected Internal Error");
            new ErrorCode(List,36862, ErrorType.Internal, @"Unexpected Internal Error");

            #endregion
        }

        static ErrorCodes errorCodes = new ErrorCodes();

        internal static ErrorCode Get(ushort value)
        {
            return (errorCodes.TryGetValue(value, out var errorCode) ? errorCode : null)!;
        }
    }
}
