# CoinChange using property-based testing with FsCheck

demonstrates writing property-based tests for a bit more involved problems

## Problem description
Given a collection of coin-values C (for example [2€, 1€, 50ct, 20ct, 10ct, 5ct, 2ct, 1ct]) and a given amount A (for example 1€5ct)
find a minimal collection (smallest possible coin-count) such that those coins sum to A (for example [1€, 5ct])

## used properties

Of course we fix the test but we also fix the coin-collection.

Why did I choose to do so?

I think that choosing a good generator-set of coins is a much harder problem then finding the change and I honestly don't want to do right now.
Of course I could always choose a random list, add 1ct, apply `distinct` to it and give it a go but I think this would make the test really brittle.
Maybe I'll try this some other time.

The first property that comes to mind is of course:

   Given an amount A the coins-values in the answer must sum to A

Checking the minimality of the answer is a bit more tricky:

   If {C_1,..,C_c} is the collection coin-values (of length c) and we are given a vector (n_1,..,n_c) of small non-negative integers:
   Calculate the scalar-product of C with n (C_1*n_1+..+C_c*n_c) and check that the result of our algorithm has
   no more items than n_1+..+n_c

## Proposed algorithms

### Greedy algorithm
We take as many of the coins with the highest value still less then the remaining amount until the remaining amount equals zero.