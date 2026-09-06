class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {

        //definition of 2dVec for sorting;
        vector<pair<int, int>> newVec;
        for (int i = 0; i < nums.size(); i++)
        {
            pair<int, int> elem = {nums[i], i};
            newVec.push_back(elem);
        }

        //sorting;
        sort(newVec.begin(), newVec.end());

        int idF = 0; int idT = nums.size()-1;
        while (newVec[idF].first + newVec[idT].first != target){
            if (newVec[idF].first + newVec[idT].first < target) 
                idF++;
            else idT--;
        }
        vector<int> ans = {newVec[idF].second, newVec[idT].second};
        return ans;
    }
};
