package com.orderservice.dtos.orders

import com.orderservice.dtos.orderlines.OrderLineDto
import com.orderservice.enums.OrderStatus
import com.orderservice.models.OrderLine
import java.time.LocalDateTime
import java.util.*

class OrderDto(
    val id: UUID,
    val userId: UUID,
    val status: OrderStatus,
    val shippingAddress: String,
    val createdAt: LocalDateTime,
    val total: Double,
    val orderLines: List<OrderLineDto>
)