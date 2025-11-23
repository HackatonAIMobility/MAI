# MAI - Customer Happiness Index for Railway Systems

## Introduction

ÖBB, Austria's national railway company, faces a significant challenge in achieving a holistic, 360-degree understanding of its customers and translating vast amounts of market research data into actionable insights for new product and service development. They particularly struggle to identify passenger "pains" (frustrations) and "gains" (delights) effectively.

**MAI (Mexican Analytics & Insights)** is designed as a pioneering solution to address this gap. For this specific challenge, MAI is applied to **Mexico's railway system** to demonstrate its capability in measuring customer happiness and sentiment, providing a scalable and transferable framework for similar analyses globally.

Our team's philosophy with MAI is to create a mixed solution that focuses equally on the **client** (railway operators) and the **end-user** (passengers). We aim to provide clients with a comprehensive experience and integrated solutions, proactively notifying them of problems reported by users through the app or social media. Simultaneously, we empower users with a reward system, offering prizes for their reports and valuable feedback. Furthermore, understanding the client's need for data to innovate, we are committed to providing MAI as an open-source solution, allowing other developers and companies to leverage our infrastructure to create new and impactful advancements.

## The Challenge: Building a Customer Happiness Index

The core objective is to create a robust "Customer Happiness Index" by tackling three key areas:

### 1. Measuring Sentiment
Develop a methodology to quantitatively measure customer satisfaction and public sentiment towards railway operators. This index aims to directly inform the future development of products and services, ensuring they align with passenger needs and preferences.

### 2. Data Sourcing & Visualization
Identify and integrate diverse data sources—both external public information (social media, news, forums) and internal data (customer emails)—to construct a comprehensive customer view. The challenge also involves designing clear and insightful visualizations for this complex dataset.

### 3. Comparative Analysis
Assess the universality and scalability of the developed methodology. The solution should ideally allow for straightforward comparative analysis between different railway systems (e.g., Mexico vs. Austria), indicating whether the model is universally applicable or specific to a particular context.

## MAI's Approach: Intelligent Insight Generation - A Dual Focus

MAI leverages advanced techniques, including Natural Language Processing (NLP) and Large Language Models (LLMs), coupled with a sophisticated **Constraint Satisfaction Tracker**, to analyze diverse data and derive meaningful insights. Our approach is characterized by a dual focus:

*   **For the Client (Railway Operators):** MAI provides integrated solutions and comprehensive insights. It proactively notifies operators about emerging problems detected from user reports within the app and across social media, ensuring rapid response and continuous service improvement. This empowers clients with actionable data to enhance passenger experience and develop new offerings.
*   **For the User (Passengers):** We foster user engagement through a robust reward system, where contributions like problem reports and feedback are recognized with prizes. This not only incentivizes participation but also ensures a continuous stream of valuable, real-world data.
*   **Open-Source Commitment:** To further benefit the industry, MAI is designed as an open-source solution. This commitment allows other developers and companies to utilize and build upon our infrastructure, fostering innovation and collaborative development in railway customer experience.

### How MAI Works: Addressing the Tasks

#### 1. Measuring Sentiment

MAI measures sentiment by:
*   **Ingesting Diverse Data:** Collecting public sentiment from social media, news articles, and online forums, alongside internal customer emails.
*   **LLM-Powered Analysis:** Utilizing LLMs to process natural language text, identifying keywords, phrases, and contexts that indicate positive or negative sentiment, as well as specific "pains" and "gains."
*   **Constraint Verification:** Employing an intelligent `ConstraintSatisfactionTracker` (as seen in `ConstraintSatisfactionTracker` class) to verify extracted insights against predefined constraints. This tracker uses a multi-stage process with intelligent weighting, allowing for partial satisfaction and prioritizing reliable constraints. For example, a constraint like "noisy trains" might be checked against multiple pieces of evidence from different sources.
*   **Scoring Mechanism:** The system assigns satisfaction scores (0.0 to 1.0) to various aspects of customer experience. This score is derived through a combination of LLM-based checks (e.g., `_check_constraint_satisfaction` function) and weighted aggregation based on constraint type and difficulty (`calculate_constraint_weight`).

#### 2. Data Sourcing & Visualization

*   **Public Data Sourcing:** MAI integrates with various public APIs and web scraping tools to gather real-time and historical data from social media platforms, news outlets, and relevant forums concerning Mexican railway operators.
*   **Internal Data Integration:** Customer emails are processed using secure NLP techniques to extract sentiment, recurring issues, and suggestions, without compromising privacy.
*   **Holistic Data Fusion:** External and internal data are combined to build a 360-degree customer view.
*   **Intuitive Dashboards:** The processed data is visualized through interactive dashboards, presenting the "Customer Happiness Index," pain points, gain points, sentiment trends over time, and geographical sentiment distribution. This allows stakeholders to quickly grasp key insights and identify areas for improvement.

#### 3. Comparative Analysis

MAI is designed with scalability and universality in mind:
*   **Configurable Constraints:** The `ConstraintSatisfactionTracker`'s constraint types and weights are configurable, allowing for adaptation to different cultural contexts and railway systems.
*   **Language Agnostic Processing:** While initially focused on Spanish for Mexico, the NLP and LLM components can be adapted or swapped to process other languages (e.g., German for Austria) with minimal architectural changes.
*   **Normalized Metrics:** The "Customer Happiness Index" and underlying satisfaction scores are normalized (0.0-1.0), facilitating direct comparison across diverse datasets and regions.
*   **Relaxation Strategies:** The `suggest_constraint_relaxation` mechanism helps identify which constraints are most amenable to relaxation, allowing for flexible analysis when comparing systems with different operational realities or data availability.

## Key Components

*   **`ConstraintSatisfactionTracker`**: Core intelligence layer for verifying insights, weighting constraints by reliability and difficulty, and generating an overall satisfaction score.
*   **`_check_constraint_satisfaction` (within `ConstraintSatisfactionTracker` context)**: Utilizes LLMs to score how well a candidate entity satisfies a given constraint based on provided evidence.
*   **`analyze_constraint_difficulty`**: Dynamically assesses the complexity of a constraint to adjust its weight in the overall satisfaction calculation.
*   **`_apply_reliability_adjustment`**: Adjusts the final score based on the mix and satisfaction of high- vs. low-reliability constraints, ensuring robust evaluation.
