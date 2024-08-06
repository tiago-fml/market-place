package com.orderservice

import com.orderservice.dtos.OrderCreateDto
import com.orderservice.dtos.OrderLineCreateDto
import com.orderservice.models.Order
import com.orderservice.models.OrderLine
import com.orderservice.repositories.OrderRepository
import com.orderservice.services.OrderService
import jakarta.xml.bind.annotation.XmlAccessOrder
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.extension.ExtendWith
import org.mockito.ArgumentCaptor
import org.mockito.InjectMocks
import org.mockito.Mock
import org.mockito.Mockito.*
import org.mockito.junit.jupiter.MockitoExtension
import org.springframework.boot.test.context.SpringBootTest
import java.util.*

@ExtendWith(MockitoExtension::class)
@SpringBootTest
class OrderServiceApplicationTests {

    @Mock
    private lateinit var orderRepo: OrderRepository

    @InjectMocks
    private lateinit var orderService: OrderService
    
    @Test
    fun contextLoads() {
    }

    fun `placeOrder should save order and orderLines correctly`() {
        // Arrange
        val userId = UUID.randomUUID()
        val shippingAddress = "123 Street City State 12345 Country"
        val orderLinesDto = listOf(
            OrderLineCreateDto(UUID.randomUUID(),"product1", 2, 10.0),
            OrderLineCreateDto(UUID.randomUUID(),"product2", 1, 20.0)
        )

        var total = orderLinesDto.sumOf { dto ->
            dto.price * dto.quantity
        }
        
        val orderCreateDto = OrderCreateDto(userId, shippingAddress, total, orderLinesDto)

        val orderLines = orderLinesDto.map { orderLineDto ->
            OrderLine(
                productId = orderLineDto.productId,
                productDescription = orderLineDto.productDescription,
                quantity = orderLineDto.quantity,
                price = orderLineDto.price
            )
        }.toList()

        val order = Order(
            userId = userId,
            total = orderLinesDto.sumOf { it.price * it.quantity },
            shippingAddress = shippingAddress,
            orderLines = orderLines
        )

        `when`(orderRepo.save(any(Order::class.java))).thenReturn(order)

        // Act
        orderService.placeOrder(orderCreateDto)

        // Assert
        val orderCaptor = ArgumentCaptor.forClass(Order::class.java)
        verify(orderRepo, times(1)).save(orderCaptor.capture())
        val savedOrder = orderCaptor.value

        assert(savedOrder.userId == userId)
        assert(savedOrder.shippingAddress == shippingAddress)
        assert(savedOrder.total == orderLinesDto.sumOf { it.price * it.quantity })

        val savedOrderLines = savedOrder.orderLines
        assert(savedOrderLines.size == orderLinesDto.size)

        orderLinesDto.forEach { dto ->
            val savedOrderLine = savedOrderLines.find { it.productId == dto.productId }
            assert(savedOrderLine != null)
            assert(savedOrderLine?.quantity == dto.quantity)
            assert(savedOrderLine?.price == dto.price)
        }
    }

}
