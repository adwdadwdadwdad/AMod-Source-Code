using System;
using System.Collections;
using System.Collections.Generic;

namespace Priority_Queue
{
	// Token: 0x0200004B RID: 75
	public sealed class FastPriorityQueue<T> : IFixedSizePriorityQueue<T, float>, IPriorityQueue<T, float>, IEnumerable<T>, IEnumerable where T : FastPriorityQueueNode
	{
		// Token: 0x06000225 RID: 549 RVA: 0x00009520 File Offset: 0x00007720
		public FastPriorityQueue(int maxNodes)
		{
			bool flag = maxNodes <= 0;
			bool flag2 = flag;
			if (flag2)
			{
				throw new InvalidOperationException("New queue size cannot be smaller than 1");
			}
			this._numNodes = 0;
			this._nodes = new T[maxNodes + 1];
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00009564 File Offset: 0x00007764
		public int Count
		{
			get
			{
				return this._numNodes;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000227 RID: 551 RVA: 0x0000957C File Offset: 0x0000777C
		public int MaxSize
		{
			get
			{
				return this._nodes.Length - 1;
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00009598 File Offset: 0x00007798
		public void Clear()
		{
			Array.Clear(this._nodes, 1, this._numNodes);
			this._numNodes = 0;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000095B8 File Offset: 0x000077B8
		public bool Contains(T node)
		{
			bool flag = node == null;
			bool flag2 = flag;
			if (flag2)
			{
				throw new ArgumentNullException("node");
			}
			bool flag3 = node.Queue != null && !this.Equals(node.Queue);
			bool flag4 = flag3;
			if (flag4)
			{
				throw new InvalidOperationException("node.Contains was called on a node from another queue.  Please call originalQueue.ResetNode() first");
			}
			bool flag5 = node.QueueIndex < 0 || node.QueueIndex >= this._nodes.Length;
			bool flag6 = flag5;
			if (flag6)
			{
				throw new InvalidOperationException("node.QueueIndex has been corrupted. Did you change it manually? Or add this node to another queue?");
			}
			return this._nodes[node.QueueIndex] == node;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00009680 File Offset: 0x00007880
		public void Enqueue(T node, float priority)
		{
			bool flag = node == null;
			bool flag2 = flag;
			if (flag2)
			{
				throw new ArgumentNullException("node");
			}
			bool flag3 = this._numNodes >= this._nodes.Length - 1;
			bool flag4 = flag3;
			if (flag4)
			{
				string str = "Queue is full - node cannot be added: ";
				throw new InvalidOperationException(str + ((node != null) ? node.ToString() : null));
			}
			bool flag5 = node.Queue != null && !this.Equals(node.Queue);
			bool flag6 = flag5;
			if (flag6)
			{
				throw new InvalidOperationException("node.Enqueue was called on a node from another queue.  Please call originalQueue.ResetNode() first");
			}
			bool flag7 = this.Contains(node);
			bool flag8 = flag7;
			if (flag8)
			{
				string str2 = "Node is already enqueued: ";
				throw new InvalidOperationException(str2 + ((node != null) ? node.ToString() : null));
			}
			node.Queue = this;
			node.Priority = priority;
			this._numNodes++;
			this._nodes[this._numNodes] = node;
			node.QueueIndex = this._numNodes;
			this.CascadeUp(node);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000097C4 File Offset: 0x000079C4
		private void CascadeUp(T node)
		{
			bool flag = node.QueueIndex > 1;
			bool flag2 = flag;
			if (flag2)
			{
				int i = node.QueueIndex >> 1;
				T t = this._nodes[i];
				bool flag3 = this.HasHigherOrEqualPriority(t, node);
				bool flag4 = !flag3;
				if (flag4)
				{
					this._nodes[node.QueueIndex] = t;
					t.QueueIndex = node.QueueIndex;
					node.QueueIndex = i;
					while (i > 1)
					{
						i >>= 1;
						T t2 = this._nodes[i];
						bool flag5 = this.HasHigherOrEqualPriority(t2, node);
						bool flag6 = flag5;
						if (flag6)
						{
							break;
						}
						this._nodes[node.QueueIndex] = t2;
						t2.QueueIndex = node.QueueIndex;
						node.QueueIndex = i;
					}
					this._nodes[node.QueueIndex] = node;
				}
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000098E8 File Offset: 0x00007AE8
		private void CascadeDown(T node)
		{
			int num = node.QueueIndex;
			int num2 = 2 * num;
			bool flag = num2 > this._numNodes;
			bool flag2 = !flag;
			if (flag2)
			{
				int num3 = num2 + 1;
				T t = this._nodes[num2];
				bool flag3 = this.HasHigherPriority(t, node);
				bool flag4 = flag3;
				if (flag4)
				{
					bool flag5 = num3 > this._numNodes;
					bool flag6 = flag5;
					if (flag6)
					{
						node.QueueIndex = num2;
						t.QueueIndex = num;
						this._nodes[num] = t;
						this._nodes[num2] = node;
						return;
					}
					T t2 = this._nodes[num3];
					bool flag7 = this.HasHigherPriority(t, t2);
					bool flag8 = flag7;
					if (flag8)
					{
						t.QueueIndex = num;
						this._nodes[num] = t;
						num = num2;
					}
					else
					{
						t2.QueueIndex = num;
						this._nodes[num] = t2;
						num = num3;
					}
				}
				else
				{
					bool flag9 = num3 > this._numNodes;
					bool flag10 = flag9;
					if (flag10)
					{
						return;
					}
					T t3 = this._nodes[num3];
					bool flag11 = this.HasHigherPriority(t3, node);
					bool flag12 = !flag11;
					if (flag12)
					{
						return;
					}
					t3.QueueIndex = num;
					this._nodes[num] = t3;
					num = num3;
				}
				for (;;)
				{
					num2 = 2 * num;
					bool flag13 = num2 > this._numNodes;
					bool flag14 = flag13;
					if (flag14)
					{
						break;
					}
					num3 = num2 + 1;
					t = this._nodes[num2];
					bool flag15 = this.HasHigherPriority(t, node);
					bool flag16 = flag15;
					if (flag16)
					{
						bool flag17 = num3 > this._numNodes;
						bool flag18 = flag17;
						if (flag18)
						{
							goto Block_9;
						}
						T t4 = this._nodes[num3];
						bool flag19 = this.HasHigherPriority(t, t4);
						bool flag20 = flag19;
						if (flag20)
						{
							t.QueueIndex = num;
							this._nodes[num] = t;
							num = num2;
						}
						else
						{
							t4.QueueIndex = num;
							this._nodes[num] = t4;
							num = num3;
						}
					}
					else
					{
						bool flag21 = num3 > this._numNodes;
						bool flag22 = flag21;
						if (flag22)
						{
							goto Block_11;
						}
						T t5 = this._nodes[num3];
						bool flag23 = this.HasHigherPriority(t5, node);
						bool flag24 = !flag23;
						if (flag24)
						{
							goto Block_12;
						}
						t5.QueueIndex = num;
						this._nodes[num] = t5;
						num = num3;
					}
				}
				node.QueueIndex = num;
				this._nodes[num] = node;
				return;
				Block_9:
				node.QueueIndex = num2;
				t.QueueIndex = num;
				this._nodes[num] = t;
				this._nodes[num2] = node;
				return;
				Block_11:
				node.QueueIndex = num;
				this._nodes[num] = node;
				return;
				Block_12:
				node.QueueIndex = num;
				this._nodes[num] = node;
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00009C30 File Offset: 0x00007E30
		private bool HasHigherPriority(T higher, T lower)
		{
			return higher.Priority < lower.Priority;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00009C5C File Offset: 0x00007E5C
		private bool HasHigherOrEqualPriority(T higher, T lower)
		{
			return higher.Priority <= lower.Priority;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00009C8C File Offset: 0x00007E8C
		public T Dequeue()
		{
			bool flag = this._numNodes <= 0;
			bool flag2 = flag;
			if (flag2)
			{
				throw new InvalidOperationException("Cannot call Dequeue() on an empty queue");
			}
			bool flag3 = !this.IsValidQueue();
			bool flag4 = flag3;
			if (flag4)
			{
				throw new InvalidOperationException("Queue has been corrupted (Did you update a node priority manually instead of calling UpdatePriority()?Or add the same node to two different queues?)");
			}
			T t = this._nodes[1];
			bool flag5 = this._numNodes == 1;
			bool flag6 = flag5;
			T result;
			if (flag6)
			{
				this._nodes[1] = default(T);
				this._numNodes = 0;
				result = t;
			}
			else
			{
				T t2 = this._nodes[this._numNodes];
				this._nodes[1] = t2;
				t2.QueueIndex = 1;
				this._nodes[this._numNodes] = default(T);
				this._numNodes--;
				this.CascadeDown(t2);
				result = t;
			}
			return result;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00009D88 File Offset: 0x00007F88
		public void Resize(int maxNodes)
		{
			bool flag = maxNodes <= 0;
			bool flag2 = flag;
			if (flag2)
			{
				throw new InvalidOperationException("Queue size cannot be smaller than 1");
			}
			bool flag3 = maxNodes < this._numNodes;
			bool flag4 = flag3;
			if (flag4)
			{
				throw new InvalidOperationException(string.Concat(new string[]
				{
					"Called Resize(",
					maxNodes.ToString(),
					"), but current queue contains ",
					this._numNodes.ToString(),
					" nodes"
				}));
			}
			T[] array = new T[maxNodes + 1];
			int num = Math.Min(maxNodes, this._numNodes);
			Array.Copy(this._nodes, array, num + 1);
			this._nodes = array;
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00009E34 File Offset: 0x00008034
		public T First
		{
			get
			{
				bool flag = this._numNodes <= 0;
				bool flag2 = flag;
				if (flag2)
				{
					throw new InvalidOperationException("Cannot call .First on an empty queue");
				}
				return this._nodes[1];
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00009E70 File Offset: 0x00008070
		public void UpdatePriority(T node, float priority)
		{
			bool flag = node == null;
			bool flag2 = flag;
			if (flag2)
			{
				throw new ArgumentNullException("node");
			}
			bool flag3 = node.Queue != null && !this.Equals(node.Queue);
			bool flag4 = flag3;
			if (flag4)
			{
				throw new InvalidOperationException("node.UpdatePriority was called on a node from another queue");
			}
			bool flag5 = !this.Contains(node);
			bool flag6 = flag5;
			if (flag6)
			{
				string str = "Cannot call UpdatePriority() on a node which is not enqueued: ";
				throw new InvalidOperationException(str + ((node != null) ? node.ToString() : null));
			}
			node.Priority = priority;
			this.OnNodeUpdated(node);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00009F28 File Offset: 0x00008128
		private void OnNodeUpdated(T node)
		{
			int num = node.QueueIndex >> 1;
			bool flag = num > 0 && this.HasHigherPriority(node, this._nodes[num]);
			bool flag2 = flag;
			if (flag2)
			{
				this.CascadeUp(node);
			}
			else
			{
				this.CascadeDown(node);
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00009F7C File Offset: 0x0000817C
		public void Remove(T node)
		{
			bool flag = node == null;
			bool flag2 = flag;
			if (flag2)
			{
				throw new ArgumentNullException("node");
			}
			bool flag3 = node.Queue != null && !this.Equals(node.Queue);
			bool flag4 = flag3;
			if (flag4)
			{
				throw new InvalidOperationException("node.Remove was called on a node from another queue");
			}
			bool flag5 = !this.Contains(node);
			bool flag6 = flag5;
			if (flag6)
			{
				string str = "Cannot call Remove() on a node which is not enqueued: ";
				throw new InvalidOperationException(str + ((node != null) ? node.ToString() : null));
			}
			bool flag7 = node.QueueIndex == this._numNodes;
			bool flag8 = flag7;
			if (flag8)
			{
				this._nodes[this._numNodes] = default(T);
				this._numNodes--;
			}
			else
			{
				T t = this._nodes[this._numNodes];
				this._nodes[node.QueueIndex] = t;
				t.QueueIndex = node.QueueIndex;
				this._nodes[this._numNodes] = default(T);
				this._numNodes--;
				this.OnNodeUpdated(t);
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000A0E0 File Offset: 0x000082E0
		public void ResetNode(T node)
		{
			bool flag = node == null;
			bool flag2 = flag;
			if (flag2)
			{
				throw new ArgumentNullException("node");
			}
			bool flag3 = node.Queue != null && !this.Equals(node.Queue);
			bool flag4 = flag3;
			if (flag4)
			{
				throw new InvalidOperationException("node.ResetNode was called on a node from another queue");
			}
			bool flag5 = this.Contains(node);
			bool flag6 = flag5;
			if (flag6)
			{
				throw new InvalidOperationException("node.ResetNode was called on a node that is still in the queue");
			}
			node.Queue = null;
			node.QueueIndex = 0;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000A176 File Offset: 0x00008376
		public IEnumerator<T> GetEnumerator()
		{
			int num;
			for (int i = 1; i <= this._numNodes; i = num + 1)
			{
				yield return this._nodes[i];
				num = i;
			}
			yield break;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000A188 File Offset: 0x00008388
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000A1A0 File Offset: 0x000083A0
		public bool IsValidQueue()
		{
			for (int i = 1; i < this._nodes.Length; i++)
			{
				bool flag = this._nodes[i] != null;
				bool flag2 = flag;
				if (flag2)
				{
					int num = 2 * i;
					bool flag3 = num < this._nodes.Length && this._nodes[num] != null && this.HasHigherPriority(this._nodes[num], this._nodes[i]);
					bool flag4 = flag3;
					bool result;
					if (flag4)
					{
						result = false;
					}
					else
					{
						int num2 = num + 1;
						bool flag5 = num2 < this._nodes.Length && this._nodes[num2] != null && this.HasHigherPriority(this._nodes[num2], this._nodes[i]);
						bool flag6 = !flag5;
						if (flag6)
						{
							goto IL_DD;
						}
						result = false;
					}
					return result;
				}
				IL_DD:;
			}
			return true;
		}

		// Token: 0x04000103 RID: 259
		private int _numNodes;

		// Token: 0x04000104 RID: 260
		private T[] _nodes;
	}
}
