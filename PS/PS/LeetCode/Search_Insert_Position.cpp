class Solution {
public:
    int searchInsert(vector<int>& nums, int target) {
        int f = 0; int t = nums.size();        
        int id = (t+f-1)/2; // 홀수면 중간값, 짝수 크기면 절반 위치에 해당하는 인덱스
        while (nums[id] != target){
            //std::cout<<id<<endl;
            if (nums[id] < target) f = id+1;
            else if (nums[id] > target) t = id;
            //f랑 t가 동일해지면 그 값이 정답.
            if (f == t) {if (nums[id] < target) id++; break;}
            id = (t+f-1)/2;
        }
        return id;

    }
};
