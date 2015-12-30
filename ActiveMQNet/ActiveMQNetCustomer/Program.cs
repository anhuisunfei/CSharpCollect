﻿using Apache.NMS;
using Apache.NMS.ActiveMQ;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMQNetCustomer
{
	class Program
	{
		static IConnectionFactory _factory = null;

		static void Main(string[] args)
		{
			try
			{
				//创建连接工厂
				_factory = new ConnectionFactory("tcp://127.0.0.1:61616/");
				//创建连接
				using (IConnection conn = _factory.CreateConnection())
				{
					//设置客户端ID
					// conn.ClientId = "Customer";
					conn.Start();
					//创建会话
					using (ISession session = conn.CreateSession())
					{
						//创建主题
						var topic = new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("topic");

						//创建消费者
						IMessageConsumer consumer = session.CreateDurableConsumer(topic, "Customer", null, false);

						//注册监听事件
						consumer.Listener += new MessageListener(consumer_Listener);

						//这句代码非常重要，
						//这里没有read方法，Session会话会被关闭，那么消费者将监听不到生产者的消息
						Console.Read();
					}

					//关闭连接
					conn.Stop();
					conn.Close();
				}

			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
			}

		}

		/// <summary>
		/// 消费监听事件
		/// </summary>
		/// <param name="message"></param>
		static void consumer_Listener(IMessage message)
		{
			ITextMessage msg = (ITextMessage)message;
			Console.WriteLine("Receive: " + msg.Text);
		}
	}
}