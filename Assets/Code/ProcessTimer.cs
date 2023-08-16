using System;
using UnityEngine;

namespace Code {
    /// <summary>
    /// 过程计时器，统计执行某个过程所需的平均时间
    /// </summary>
    public class ProcessTimer {
        private double _accumulatedTime = 0; // 此计时器累计的时间；单位为秒
        private long _processCount = 0; // 此计时器累计的帧数

        private double _startTime; // 最近一次开始计时的时间；单位为秒
        private bool _ticking; // 是否正在计时
        private long _notificationInterval = long.MaxValue; // 提醒周期
        private long _notificationCount = 0; // 提醒计数

        private readonly double EPS = 1E-8;

        public ProcessTimer(bool startImmediately) {
            if (startImmediately) start();
        }

        public void setRegularNotification(long interval) {
            _notificationInterval = interval;
        }

        public bool start() {
            if (_ticking) return false;

            _ticking = true;
            _startTime = Time.unscaledTimeAsDouble;
            return true;
        }

        public bool updateAndPause() {
            if (!_ticking) return false;

            _ticking = false;
            _accumulatedTime += (Time.unscaledTimeAsDouble - _startTime);
            _processCount += 1;

            _notificationCount += 1;
            if (_notificationCount >= _notificationInterval) {
                _notificationCount = 0;
                throw new TimerNotificationException();
            }

            return true;
        }

        public double accumulatedTime() {
            return _accumulatedTime;
        }

        public long processCount() {
            return _processCount;
        }

        /// <summary>
        /// 返回上次更新后，此计时器统计的执行过程的平均时间；单位为秒
        /// </summary>
        public double avgProcessTime() {
            return _accumulatedTime / Math.Max(_processCount, EPS);
        }
    }

    public class TimerNotificationException : Exception {
        public TimerNotificationException() : base() {
        }

        public TimerNotificationException(String message) : base(message) {
        }
    }
}