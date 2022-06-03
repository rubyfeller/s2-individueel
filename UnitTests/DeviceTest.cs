using Autofac.Extras.Moq;
using Moq;
using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using System.Collections.Generic;
using Xunit;
using LOGIC.DeviceLogic;

namespace UnitTests
{
    public class DeviceTest
    {
        private readonly Mock<IDeviceDal> _deviceDal = new Mock<IDeviceDal>();

        private readonly DeviceLogic _DeviceLogic;

        public DeviceTest()
        {
            _DeviceLogic = new DeviceLogic(_deviceDal.Object);
        }

        private List<DeviceDTO> GetSampleDevices()
        {
            List<DeviceDTO> devices = new List<DeviceDTO>
            {
                new DeviceDTO
                {
                    DeviceId = 1023,
                    ClientId = null,
                    TicketId = null,
                    DeviceName = "iPhone 12",
                    DeviceVersion = "12",
                    Brand = "Apple",
                    OsVersion = "13",
                    SerialNumber = "123456",
                },

                new DeviceDTO
                {
                    DeviceId = 1024,
                    ClientId = null,
                    TicketId = null,
                    DeviceName = "Samsung Galaxy S8",
                    DeviceVersion = "S8",
                    Brand = "Samsung",
                    OsVersion = "9",
                    SerialNumber = "123456",
                }
            };
            return devices;
        }

        private DeviceDTO GetSampleDevice()
        {
            DeviceDTO device = new DeviceDTO
            {
                DeviceId = 1025,
                ClientId = null,
                TicketId = null,
                DeviceName = "Samsung Galaxy S9",
                DeviceVersion = "S9",
                Brand = "Samsung",
                OsVersion = "9",
                SerialNumber = "123456",
            };

            return device;
        }

        [Fact]
        public void TestIsDeviceDTOTransferedToLogicObject()
        {
            // Arrange
            _deviceDal.Setup(x => x.GetDevices()).Returns(GetSampleDevices());

            var expectedResult = GetSampleDevices();

            // Act
            var actualResult = _DeviceLogic.GetDevices();

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Device>(actualResult[0]);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].DeviceId, actualResult[i].DeviceId);
                Assert.Equal(expectedResult[i].ClientId, actualResult[i].ClientId);
                Assert.Equal(expectedResult[i].TicketId, actualResult[i].TicketId);
                Assert.Equal(expectedResult[i].DeviceName, actualResult[i].DeviceName);
                Assert.Equal(expectedResult[i].DeviceVersion, actualResult[i].DeviceVersion);
                Assert.Equal(expectedResult[i].Brand, actualResult[i].Brand);
                Assert.Equal(expectedResult[i].OsVersion, actualResult[i].OsVersion);
                Assert.Equal(expectedResult[i].SerialNumber, actualResult[i].SerialNumber);

            }
            Assert.Equal(2, expectedResult.Count);
        }

        [Fact]
        public void TestGetDevices()
        {
            // Arrange
            _deviceDal.Setup(x => x.GetDevices()).Returns(GetSampleDevices);

            var expectedResult = GetSampleDevices();

            var actualResult = _DeviceLogic.GetDevices();

            // Assert   
            Assert.True(actualResult != null);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].DeviceId, actualResult[i].DeviceId);
                Assert.Equal(expectedResult[i].ClientId, actualResult[i].ClientId);
                Assert.Equal(expectedResult[i].TicketId, actualResult[i].TicketId);
                Assert.Equal(expectedResult[i].DeviceName, actualResult[i].DeviceName);
                Assert.Equal(expectedResult[i].DeviceVersion, actualResult[i].DeviceVersion);
                Assert.Equal(expectedResult[i].Brand, actualResult[i].Brand);
                Assert.Equal(expectedResult[i].OsVersion, actualResult[i].OsVersion);
                Assert.Equal(expectedResult[i].SerialNumber, actualResult[i].SerialNumber);
            }
        }

        [Fact]
        public void TestAddDevice()
        {
            // Arrange
            var device = new DeviceDTO
            {
                DeviceId = 1025,
                ClientId = null,
                TicketId = null,
                DeviceName = "Samsung Tab",
                DeviceVersion = "1",
                Brand = "Samsung",
                OsVersion = "13",
                SerialNumber = "123456",
            };

            _deviceDal.Setup(x => x.AddDevice(device));


            // Act
            _DeviceLogic.AddDevice(device);

            // Assert
            _deviceDal.Verify(x => x.AddDevice(device), Times.Once);
        }

        [Fact]
        public void TestUpdateDevice()
        {
            // Arrange
            var device = new DeviceDTO
            {
                DeviceId = 1025,
                ClientId = null,
                TicketId = null,
                DeviceName = "Samsung Tab 2",
                DeviceVersion = "2",
                Brand = "Samsung",
                OsVersion = "14",
                SerialNumber = "123456",
            };

            _deviceDal.Setup(x => x.UpdateDevice(device));

            // Act
            _DeviceLogic.UpdateDevice(device);

            // Assert
            _deviceDal.Verify(x => x.UpdateDevice(device), Times.Once);
        }

        [Fact]
        public void TestDeleteDevice()
        {
            // Arrange
            int deviceId = 1025;
            _deviceDal.Setup(x => x.DeleteDevice(deviceId));

            // Act
            _DeviceLogic.DeleteDevice(deviceId);

            // Assert
            _deviceDal.Verify(x => x.DeleteDevice(deviceId), Times.Once);
        }

        [Fact]
        public void TestGetDevice()
        {
            // Arrange
            var device = GetSampleDevice();

            _deviceDal.Setup(x => x.GetDevice(device.DeviceId)).Returns(device);

            var expectedResult = GetSampleDevice();

            var actualResult = _DeviceLogic.GetDevice(device.DeviceId);

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Device>(actualResult);
            Assert.Equal(expectedResult.DeviceId, actualResult.DeviceId);
            Assert.Equal(expectedResult.ClientId, actualResult.ClientId);
            Assert.Equal(expectedResult.TicketId, actualResult.TicketId);
            Assert.Equal(expectedResult.DeviceName, actualResult.DeviceName);
            Assert.Equal(expectedResult.DeviceVersion, actualResult.DeviceVersion);
            Assert.Equal(expectedResult.Brand, actualResult.Brand);
            Assert.Equal(expectedResult.OsVersion, actualResult.OsVersion);
            Assert.Equal(expectedResult.SerialNumber, actualResult.SerialNumber);
        }
    }
}