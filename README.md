# CoinChange using property-based testing with FsCheck

demonstrates writing property-based tests for a bit more involved problems

## Problem description
Given a collection of coin-values C (for example [2€, 1€, 50ct, 20ct, 10ct, 5ct, 2ct, 1ct]) and a given amount A (for example 1€5ct)
find a minimal collection (smallest possible coin-count) such that those coins sum to A (for example [1€, 5ct])

## used properties
The first property that comes to mind is of course:

   Given an amount A the coins-values in the answer must sum to A

Checking the minimality of the answer is a bit more tricky:

   Given a collection C of coin-values (of length c) and a vector n of small positive integers of length c
   Calculate the scalar-product of C with n (C_1*n_1+..+C_c*n_c) R and check that the result of our function
   no more items than n_1+..+n_c

Of course the second one might or might not work (meaning it might be rather brittle in finding counter-examples for wrong algorithms).
Maybe in this situation a formal proof or even a classical unit test is more 

To check this the first algorithm will be the naive "greedy" algorithm first.