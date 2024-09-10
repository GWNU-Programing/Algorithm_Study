"""
지름길 개수 : n
고속도로 길이 : d

0 ~ d까지 운전해야하는 거리의 최솟값 
출발, 도착, 가중치 (방향 그래프) -> 최소 경로 탐색 -> 다익스트라 
"""

import sys, heapq
input = sys.stdin.readline
n, target = map(int,input().split())

graph = [[] for _ in range(target+1)]
for i in range(target):
    graph[i].append((1, i+1))  # 가중치, 도착지점 

for _ in range(n):
    s,e,d = map(int,input().split())
    if e <= target and d < e-s:
        graph[s].append((d,e))

q = []
heapq.heappush(q,(0,0))
visited = [0] + [float("inf")] * target

while q:
    now_w, now_e = heapq.heappop(q)

    for next_w, next_e in graph[now_e]:
        cost = visited[now_e] + next_w 
        if cost < visited[next_e]:
            visited[next_e] = cost
            heapq.heappush(q,(cost, next_e))

print(visited[target])
