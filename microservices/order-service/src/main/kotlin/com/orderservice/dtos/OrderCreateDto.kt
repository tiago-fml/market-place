package com.orderservice.dtos

import java.util.UUID

class OrderCreateDto(
    val userId: UUID,
    val shippingAddress: String,
    val total: Double,
    val orderLines: List<OrderLineCreateDto> = listOf(),
)