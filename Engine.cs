using CovisartMotionSimulatorLibrary.TwinCatNotification;
using TwinCAT.Ads;

namespace CovisartMotionSimulatorLibrary
{
    public class Engine
    {
        public string engineType;

        public TwinCatVariable<bool> Power { get; }

        public TwinCatVariable<bool> EnExactPosition { get; }

        public TwinCatVariable<double> Position { get; }

        public TwinCatVariable<bool> ResetError { get; }

        public TwinCatVariable<bool> ResetDrive { get; }

        public TwinCatVariable<bool> ResetNc { get; }

        public TwinCatVariable<bool> StopAxis { get; }

        public TwinCatVariable<double> StopAxisDec { get; }

        public TwinCatVariable<bool> SetPositionZero { get; }

        public TwinCatVariable<bool> CalibrateAxis { get; }

        public TwinCatVariable<bool> Powered { get; }

        public TwinCatErrorVariable PowerError { get; }

        public TwinCatVariable<UInt16> PowerErrorId { get; }

        public TwinCatErrorVariable ExactPositionError { get; }

        public TwinCatVariable<bool> PositionUp { get; }

        public TwinCatVariable<bool> PositionDown { get; }

        public TwinCatVariable<UInt16> ExactPositionErrorId { get; }

        public TwinCatErrorVariable ResetErrorStatus { get; }

        public TwinCatVariable<UInt16> ResetErrorStatusId { get; }

        public TwinCatErrorVariable AxisError { get; }

        public TwinCatVariable<UInt16> AxisErrorId { get; }

        public TwinCatErrorVariable StopAxisError { get; }

        public TwinCatVariable<UInt16> StopAxisErrorId { get; }

        public TwinCatErrorVariable SetPositionError { get; }

        public TwinCatVariable<UInt16> SetPositionErrorId { get; }

        public TwinCatVariable<double> CurrentPosition { get; }

        public TwinCatVariable<bool> CalibrationDone { get; }

        public TwinCatVariable<double> ModuloActPos { get; }

        public TwinCatVariable<bool> Operational { get; }

        public TwinCatVariable<double> ActPosition { get; }
        public TwinCatVariable<double> ActVelocity { get; }
        public TwinCatVariable<double> PosDifference { get; }
        public TwinCatVariable<bool> ActAcceleration { get; }

        //Özel ayarlar
        public TwinCatVariable<double> Reference_Velocity { get; }

        public TwinCatVariable<double> Maximum_Velocity { get; }

        public TwinCatVariable<double> Maximum_Acceleration { get; }

        public TwinCatVariable<double> Maximum_Deceleration { get; }

        public TwinCatVariable<double> Default_Acceleration { get; }
        public TwinCatVariable<double> Default_Deceleration { get; }
        public TwinCatVariable<double> Default_Jerk { get; }
        public TwinCatVariable<double> Homing_Velocity_towards_plc_cam { get; }
        public TwinCatVariable<double> Homing_Velocity_off_plc_cam { get; }
        public TwinCatVariable<double> Manual_Velocity_Fast { get; }
        public TwinCatVariable<double> Manual_Velocity_Slow { get; }
        public TwinCatVariable<double> Jog_Increment_Forward { get; }
        public TwinCatVariable<double> Jog_Increment_Backward { get; }
        // public TwinCatVariable<double> Fast_Axis_Stop_Signal_Type_optional { get; }
        public TwinCatVariable<double> Fast_Acceleration_optional { get; }
        public TwinCatVariable<double> Fast_Deceleration_optional { get; }
        public TwinCatVariable<double> Fast_Jerk_optional { get; }
        public TwinCatVariable<bool> Soft_Position_Limit_Minimum_Monitoring { get; }
        public TwinCatVariable<double> Minimum_Position { get; }
        public TwinCatVariable<bool> Soft_Position_Limit_Maximum_Monitoring { get; }
        public TwinCatVariable<double> Maximum_Position { get; }
        public TwinCatVariable<bool> Position_Lag_Monitoring { get; }
        public TwinCatVariable<double> Maximum_Position_Lag_Value { get; }
        public TwinCatVariable<double> Maximum_Position_Lag_Filter_Time { get; }
        public TwinCatVariable<bool> Position_Range_Monitoring { get; }
        public TwinCatVariable<double> Position_Range_Window { get; }
        public TwinCatVariable<bool> Target_Position_Monitoring { get; }
        public TwinCatVariable<double> Target_Position_Window { get; }
        public TwinCatVariable<double> Target_Position_Monitoring_Time { get; }
        public TwinCatVariable<bool> In_Target_Alarm { get; }
        public TwinCatVariable<double> In_Target_Timeout { get; }
        public TwinCatVariable<bool> Motion_Monitoring { get; }
        public TwinCatVariable<double> Motion_Monitoring_Window { get; }
        public TwinCatVariable<double> Motion_Monitoring_Time { get; }
        //  public TwinCatVariable<double> Setpoint_Generator_Type { get; }
        //   public TwinCatVariable<double> Velocity_Override_Type { get; }
        public TwinCatVariable<double> Rapid_Traverse_Velocity_GO { get; }
        public TwinCatVariable<double> Velo_Jump_Factor { get; }
        public TwinCatVariable<double> Tolerance_ball_auxiliary_axis { get; }
        public TwinCatVariable<double> Max_position_deviation_aux_axis { get; }
        public TwinCatVariable<bool> Position_Correction { get; }


        public TwinCatVariable<double> Status_Lag_Distance_Min_Max { get; }
        public TwinCatVariable<double> Status_Actual_Velocity { get; }
        public TwinCatVariable<double> Status_Setpoint_Velocity { get; }
        public TwinCatVariable<double> Status_Setpoint_Position { get; }
        public TwinCatVariable<double> Status_Override { get; }
        public TwinCatVariable<double> Status_Total_Control_Output { get; }
        public TwinCatVariable<double> Status_Error { get; }

        public TwinCatVariable<bool> Status_Ready { get; }
        public TwinCatVariable<bool> Status_Calibrated { get; }
        public TwinCatVariable<bool> Status_Has_Job { get; }
        public TwinCatVariable<bool> Status_Not_Moving { get; }
        public TwinCatVariable<bool> Status_Moving_Fw { get; }
        public TwinCatVariable<bool> Status_Moving_Bw { get; }

        public TwinCatVariable<bool> Status_Couple_Mode { get; }
        public TwinCatVariable<bool> Status_In_Target_Pos { get; }
        public TwinCatVariable<bool> Status_In_Pos_Range { get; }

        public TwinCatVariable<bool> Status_Controller { get; }
        public TwinCatVariable<bool> Status_Feed_Fw { get; }
        public TwinCatVariable<bool> Status_Feed_Bw { get; }

        public TwinCatVariable<double> Status_Controller_Kv_Factor { get; }
        public TwinCatVariable<double> Status_Target_Position { get; }
        public TwinCatVariable<double> Status_Target_Velocity { get; }
        public TwinCatVariable<double> Status_Referance_Velocity { get; }

        public string Name { get; }

        public Engine(TcAdsClient adsClient, string engineType, TwinCatNotifierManager notificationList, string engineInfo)
        {
            Name = engineInfo;
            this.engineType = engineType.ToUpper();
            Power = new TwinCatVariable<bool>(adsClient, "Power", engineType, notificationList);

            EnExactPosition = new TwinCatVariable<bool>(adsClient, "EnExactPostion", engineType, notificationList);

            Position = new TwinCatVariable<double>(adsClient, "Position", engineType, notificationList);

            ResetError = new TwinCatVariable<bool>(adsClient, "ResetError", engineType, notificationList);

            ResetDrive = new TwinCatVariable<bool>(adsClient, "ResetDrive", engineType, notificationList);

            //ResetNc = new TwinCatVariable<bool>(adsClient, "ResetNc", engineType, notificationList); ;

            StopAxis = new TwinCatVariable<bool>(adsClient, "StopAxis", engineType, notificationList); ;

            //StopAxisDec = new TwinCatVariable<double>(adsClient, "StopAxisDec", engineType, notificationList); ;

            SetPositionZero = new TwinCatVariable<bool>(adsClient, "SetPositionZero", engineType, notificationList); ;

            CalibrateAxis = new TwinCatVariable<bool>(adsClient, "CalibrateAxis", engineType, notificationList); ;

            Powered = new TwinCatVariable<bool>(adsClient, "Powered", engineType, notificationList);

            PositionUp = new TwinCatVariable<bool>(adsClient, "PositionUp", engineType, notificationList);
            PositionDown = new TwinCatVariable<bool>(adsClient, "PositionDown", engineType, notificationList);


            PowerErrorId = new TwinCatVariable<UInt16>(adsClient, "PowerErrorId", engineType, notificationList); ;
            PowerError = new TwinCatErrorVariable(adsClient, "PowerError", engineType, notificationList, PowerErrorId); ;
            ExactPositionErrorId = new TwinCatVariable<UInt16>(adsClient, "ExactPostionErrorId", engineType, notificationList); ;

            ExactPositionError = new TwinCatErrorVariable(adsClient, "ExactPostionError", engineType, notificationList, ExactPositionErrorId); ;



            ResetErrorStatusId = new TwinCatVariable<UInt16>(adsClient, "ResetErrorStatusId", engineType, notificationList); ;
            ResetErrorStatus = new TwinCatErrorVariable(adsClient, "ResetErrorStatus", engineType, notificationList, ResetErrorStatusId); ;


            AxisErrorId = new TwinCatVariable<UInt16>(adsClient, "AxisErrorId", engineType, notificationList); ;
            AxisError = new TwinCatErrorVariable(adsClient, "AxisError", engineType, notificationList, AxisErrorId); ;


            StopAxisErrorId = new TwinCatVariable<UInt16>(adsClient, "StopAxisErrorId", engineType, notificationList); ;
            StopAxisError = new TwinCatErrorVariable(adsClient, "StopAxisError", engineType, notificationList, StopAxisErrorId); ;


            SetPositionErrorId = new TwinCatVariable<UInt16>(adsClient, "SetPositionErrorId", engineType, notificationList); ;
            SetPositionError = new TwinCatErrorVariable(adsClient, "SetPositionError", engineType, notificationList, SetPositionErrorId); ;

            CurrentPosition = new TwinCatVariable<double>(adsClient, "CurrentPosition", engineType, notificationList); ;

            CalibrationDone = new TwinCatVariable<bool>(adsClient, "CalibrationDone", engineType, notificationList); ;

            ActPosition = new TwinCatVariable<double>(adsClient, "ActPosition", engineType, notificationList); ;

            ModuloActPos = new TwinCatVariable<double>(adsClient, "ModuloActPos", engineType, notificationList); ;

            ActVelocity = new TwinCatVariable<double>(adsClient, "ActVelocity", engineType, notificationList); ;

            PosDifference = new TwinCatVariable<double>(adsClient, "PosDifference", engineType, notificationList); ;

            ActAcceleration = new TwinCatVariable<bool>(adsClient, "ActAcceleration", engineType, notificationList); ;

            Operational = new TwinCatVariable<bool>(adsClient, "Operational", engineType, notificationList);

            /////////Özel ayalar
            ////Maximum_Dynamics
            Reference_Velocity = new TwinCatVariable<double>(adsClient, "Reference_Velocity", engineType, notificationList) { isSettings = true, settingCategoryName = "Maximum_Dynamics" };

            Maximum_Velocity = new TwinCatVariable<double>(adsClient, "Maximum_Velocity", engineType, notificationList) { isSettings = true, settingCategoryName = "Maximum_Dynamics" };

            Maximum_Acceleration = new TwinCatVariable<double>(adsClient, "Maximum_Acceleration", engineType, notificationList) { isSettings = true, settingCategoryName = "Maximum_Dynamics" };

            Maximum_Deceleration = new TwinCatVariable<double>(adsClient, "Maximum_Deceleration", engineType, notificationList) { isSettings = true, settingCategoryName = "Maximum_Dynamics" };
            //Default_Dynamics
            Default_Acceleration = new TwinCatVariable<double>(adsClient, "Default_Acceleration", engineType, notificationList) { isSettings = true, settingCategoryName = "Default_Dynamics" };

            Default_Deceleration = new TwinCatVariable<double>(adsClient, "Default_Deceleration", engineType, notificationList) { isSettings = true, settingCategoryName = "Default_Dynamics" };

            Default_Jerk = new TwinCatVariable<double>(adsClient, "Default_Jerk", engineType, notificationList) { isSettings = true, settingCategoryName = "Maximum_Dynamics" };
            //Manual_Motion_and_Homing
            Homing_Velocity_towards_plc_cam = new TwinCatVariable<double>(adsClient, "Homing_Velocity_towards_plc_cam", engineType, notificationList) { isSettings = true, settingCategoryName = "Manual_Motion_and_Homing" };

            Homing_Velocity_off_plc_cam = new TwinCatVariable<double>(adsClient, "Homing_Velocity_off_plc_cam", engineType, notificationList) { isSettings = true, settingCategoryName = "Manual_Motion_and_Homing" };

            Manual_Velocity_Fast = new TwinCatVariable<double>(adsClient, "Manual_Velocity_Fast", engineType, notificationList) { isSettings = true, settingCategoryName = "Manual_Motion_and_Homing" };

            Manual_Velocity_Slow = new TwinCatVariable<double>(adsClient, "Manual_Velocity_Slow", engineType, notificationList) { isSettings = true, settingCategoryName = "Manual_Motion_and_Homing" };

            Jog_Increment_Forward = new TwinCatVariable<double>(adsClient, "Jog_Increment_Forward", engineType, notificationList) { isSettings = true, settingCategoryName = "Manual_Motion_and_Homing" };

            Jog_Increment_Backward = new TwinCatVariable<double>(adsClient, "Jog_Increment_Backward", engineType, notificationList) { isSettings = true, settingCategoryName = "Manual_Motion_and_Homing" };

            //Fast_Axis_Stop
            //Fast_Axis_Stop_Signal_Type_optional = new TwinCatVariable<double>(adsClient, "Fast_Axis_Stop_Signal_Type_optional", engineType, notificationList) { isSettings = true, settingCategoryName = "Fast_Axis_Stop" };

            Fast_Acceleration_optional = new TwinCatVariable<double>(adsClient, "Fast_Acceleration_optional", engineType, notificationList) { isSettings = true, settingCategoryName = "Fast_Axis_Stop" };

            Fast_Deceleration_optional = new TwinCatVariable<double>(adsClient, "Fast_Deceleration_optional", engineType, notificationList) { isSettings = true, settingCategoryName = "Fast_Axis_Stop" };

            Fast_Jerk_optional = new TwinCatVariable<double>(adsClient, "Fast_Jerk_optional", engineType, notificationList) { isSettings = true, settingCategoryName = "Fast_Axis_Stop" };

            //Limit_Switches
            Soft_Position_Limit_Minimum_Monitoring = new TwinCatVariable<bool>(adsClient, "Soft_Position_Limit_Minimum_Monitoring", engineType, notificationList) { isSettings = true, settingCategoryName = "Limit_Switches" };

            Minimum_Position = new TwinCatVariable<double>(adsClient, "Minimum_Position", engineType, notificationList) { isSettings = true, settingCategoryName = "Limit_Switches" };

            Soft_Position_Limit_Maximum_Monitoring = new TwinCatVariable<bool>(adsClient, "Soft_Position_Limit_Maximum_Monitoring", engineType, notificationList) { isSettings = true, settingCategoryName = "Limit_Switches" };

            Maximum_Position = new TwinCatVariable<double>(adsClient, "Maximum_Position", engineType, notificationList) { isSettings = true, settingCategoryName = "Limit_Switches" };

            //Monitoring
            Position_Lag_Monitoring = new TwinCatVariable<bool>(adsClient, "Position_Lag_Monitoring", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Maximum_Position_Lag_Value = new TwinCatVariable<double>(adsClient, "Maximum_Position_Lag_Value", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Maximum_Position_Lag_Filter_Time = new TwinCatVariable<double>(adsClient, "Maximum_Position_Lag_Filter_Time", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Position_Range_Monitoring = new TwinCatVariable<bool>(adsClient, "Position_Range_Monitoring", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Position_Range_Window = new TwinCatVariable<double>(adsClient, "Position_Range_Window", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Target_Position_Monitoring = new TwinCatVariable<bool>(adsClient, "Target_Position_Monitoring", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Target_Position_Window = new TwinCatVariable<double>(adsClient, "Target_Position_Window", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Target_Position_Monitoring_Time = new TwinCatVariable<double>(adsClient, "Target_Position_Monitoring_Time", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            In_Target_Alarm = new TwinCatVariable<bool>(adsClient, "In_Target_Alarm", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            In_Target_Timeout = new TwinCatVariable<double>(adsClient, "In_Target_Timeout", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Motion_Monitoring = new TwinCatVariable<bool>(adsClient, "Motion_Monitoring", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Motion_Monitoring_Window = new TwinCatVariable<double>(adsClient, "Motion_Monitoring_Window", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            Motion_Monitoring_Time = new TwinCatVariable<double>(adsClient, "Motion_Monitoring_Time", engineType, notificationList) { isSettings = true, settingCategoryName = "Monitoring" };

            //Setpoint_Generator
            //Setpoint_Generator_Type = new TwinCatVariable<double>(adsClient, "Setpoint_Generator_Type", engineType, notificationList) { isSettings = true, settingCategoryName = "Setpoint_Generator" };

            //Velocity_Override_Type = new TwinCatVariable<double>(adsClient, "Velocity_Override_Type", engineType, notificationList) { isSettings = true, settingCategoryName = "Setpoint_Generator" };
            //NCI_Parameter
            Rapid_Traverse_Velocity_GO = new TwinCatVariable<double>(adsClient, "Rapid_Traverse_Velocity_GO", engineType, notificationList) { isSettings = true, settingCategoryName = "NCI_Parameter" };

            Velo_Jump_Factor = new TwinCatVariable<double>(adsClient, "Velo_Jump_Factor", engineType, notificationList) { isSettings = true, settingCategoryName = "NCI_Parameter" };

            Tolerance_ball_auxiliary_axis = new TwinCatVariable<double>(adsClient, "Tolerance_ball_auxiliary_axis", engineType, notificationList) { isSettings = true, settingCategoryName = "NCI_Parameter" };

            Max_position_deviation_aux_axis = new TwinCatVariable<double>(adsClient, "Max_position_deviation_aux_axis", engineType, notificationList) { isSettings = true, settingCategoryName = "NCI_Parameter" };
            //Other_Settings
            Position_Correction = new TwinCatVariable<bool>(adsClient, "Position_Correction", engineType, notificationList) { isSettings = true, settingCategoryName = "Other_Settings" };


            Status_Lag_Distance_Min_Max = new TwinCatVariable<double>(adsClient, "Status_Lag_Distance_Min_Max_", engineType, notificationList);

            Status_Actual_Velocity = new TwinCatVariable<double>(adsClient, "Status_Actual_Velocity_", engineType, notificationList);

            Status_Setpoint_Velocity = new TwinCatVariable<double>(adsClient, "Status_Setpoint_Velocity_", engineType, notificationList);

            Status_Setpoint_Position = new TwinCatVariable<double>(adsClient, "Status_Setpoint_Position_", engineType, notificationList);

            Status_Override = new TwinCatVariable<double>(adsClient, "Status_Override_", engineType, notificationList);

            Status_Total_Control_Output = new TwinCatVariable<double>(adsClient, "Status_Total_Control_Output_", engineType, notificationList);

            Status_Error = new TwinCatVariable<double>(adsClient, "Status_Error_", engineType, notificationList);

            Status_Ready = new TwinCatVariable<bool>(adsClient, "Status_Ready_", engineType, notificationList);
            Status_Calibrated = new TwinCatVariable<bool>(adsClient, "Status_Calibrated_", engineType, notificationList);
            Status_Has_Job = new TwinCatVariable<bool>(adsClient, "Status_Has_Job_", engineType, notificationList);
            Status_Not_Moving = new TwinCatVariable<bool>(adsClient, "Status_Not_Moving_", engineType, notificationList);
            Status_Moving_Fw = new TwinCatVariable<bool>(adsClient, "Status_Moving_Fw_", engineType, notificationList);
            Status_Moving_Bw = new TwinCatVariable<bool>(adsClient, "Status_Moving_Bw_", engineType, notificationList);

            Status_Couple_Mode = new TwinCatVariable<bool>(adsClient, "Status_Couple_Mode_", engineType, notificationList);
            Status_In_Target_Pos = new TwinCatVariable<bool>(adsClient, "Status_In_Target_Pos_", engineType, notificationList);
            Status_In_Pos_Range = new TwinCatVariable<bool>(adsClient, "Status_In_Pos_Range_", engineType, notificationList);

            Status_Controller = new TwinCatVariable<bool>(adsClient, "Status_Controller_", engineType, notificationList);
            Status_Feed_Fw = new TwinCatVariable<bool>(adsClient, "Status_Feed_Fw_", engineType, notificationList);
            Status_Feed_Bw = new TwinCatVariable<bool>(adsClient, "Status_Feed_Bw_", engineType, notificationList);

            Status_Controller_Kv_Factor = new TwinCatVariable<double>(adsClient, "Status_Controller_Kv_Factor_", engineType, notificationList);
            Status_Target_Position = new TwinCatVariable<double>(adsClient, "Status_Target_Position_", engineType, notificationList);
            Status_Target_Velocity = new TwinCatVariable<double>(adsClient, "Status_Target_Velocity_", engineType, notificationList);
            Status_Referance_Velocity = new TwinCatVariable<double>(adsClient, "Status_Referance_Velocity_", engineType, notificationList);
        }
    }

}