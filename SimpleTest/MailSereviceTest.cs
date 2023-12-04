using Notification.Objects;
using Moq;
using Xunit;
using Castle.Core.Smtp;

namespace SimpleTest
{
    public class MailServiceTest
    {
        [Fact]
        public void SendNotificationTest()
        {
            //Arrange
            var emailSenderMock = new Mock<IMailService>();
            emailSenderMock.Setup(sender => sender.SendNotificationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            var emailService = new MailService();

            //Act
            // �������� ����� �������� email � ��������� �������
            var result =  emailService.SendNotificationAsync("dunaevskyilya@gmail.com", "Fangarh.666@yandex.com", "Hello World");

            // Assert
            // �������� ����������� (assertion) ��� �������� �������� �������� email. ��������:
            //Assert.True();
            emailSenderMock.Verify(sender => sender.SendNotificationAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
