package com.orderservice.services

import com.orderservice.dtos.OrderCreateDto
import com.orderservice.models.Order
import com.orderservice.models.OrderLine
import com.orderservice.repositories.OrderRepository
import org.springframework.stereotype.Service

@Service
class OrderService(private val orderRepo: OrderRepository) {
    
    fun placeOrder(orderCreateDto: OrderCreateDto) {
        val orderLines = orderCreateDto.orderLines.map { orderLineDto ->
            OrderLine.fromCreateDto(orderLineDto)
        }.toList()
        
        val order = Order(
            userId = orderCreateDto.userId,
            total = orderCreateDto.total,
            shippingAddress = orderCreateDto.shippingAddress,
            orderLines = orderLines
        )

        orderLines.forEach { it.order = order }
        
        orderRepo.save(order)
    }
}