// 양수, 음수 위치 중 가장 큰 값이 있는 범위부터 시작(가장 큰 값은 가급적 편도로만 움직여야 하므로)
// * 양수, 음수 배열로 구분하여 각각 내림차순으로 정렬
// * 두 배열의 요소를 m만큼의 간격으로 '값 * 2'의 누적 합을 구함
// * 두 배열 중 더 큰 값이 있는 배열의 해당 값을 1번 뺌

let input = readLine()!.split(separator: " ").map { Int($0)! }
let n: Int = input[0], m: Int = input[1]

let position = readLine()!.split(separator: " ").map { Int($0)! }

var sum: Int = 0
var pos_num: [Int] = []
var neg_num: [Int] = []

position.forEach {
    if $0 >= 0 {
        pos_num.append($0)
    } else {
        neg_num.append(abs($0))
    }
}

pos_num.sort(by: >)
neg_num.sort(by: >)

for i in stride(from: 0, to: pos_num.count, by: m) {
    sum += pos_num[i] * 2
}

for i in stride(from: 0, to: neg_num.count, by: m) {
    sum += neg_num[i] * 2
}

if pos_num.count > 0 && neg_num.count > 0 { sum -= max(pos_num[0], neg_num[0]) }
else if pos_num.count == 0 { sum -= neg_num[0] }
else { sum -= pos_num[0] }

print(sum)
